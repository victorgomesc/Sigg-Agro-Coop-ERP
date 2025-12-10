using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using SiggAgroCoop.Application.DTOs.Auth;
using SiggAgroCoop.Application.Interfaces;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Enums;
using SiggAgroCoop.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace SiggAgroCoop.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _users;
    private readonly IFarmRepository _farms;
    private readonly IConfiguration _config;

    public AuthService(IUserRepository users, IFarmRepository farms, IConfiguration config)
    {
        _users = users;
        _farms = farms;
        _config = config;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto)
    {
        var role = Enum.Parse<UserRole>(dto.Role, true);

        var user = new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = role
        };

        // Se o usuário novo for Admin → cria automaticamente uma fazenda
        if (role == UserRole.Admin)
        {
            var farm = new Farm
            {
                Name = $"{dto.FullName}'s Farm"
            };

            await _farms.AddAsync(farm);
            user.FarmId = farm.Id;
        }

        await _users.AddAsync(user);

        return GenerateToken(user);
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _users.GetByEmailAsync(dto.Email)
                   ?? throw new Exception("Invalid credentials.");

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Invalid credentials.");

        return GenerateToken(user);
    }

    private AuthResponseDto GenerateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim("farmId", user.FarmId?.ToString() ?? "")
        };

        var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new AuthResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Role = user.Role.ToString(),
            UserId = user.Id,
            FarmId = user.FarmId
        };
    }
}
