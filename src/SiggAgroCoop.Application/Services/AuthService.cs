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

public class AuthService(IUserRepository users, IConfiguration config) : IAuthService
{
    private readonly IUserRepository _users = users;
    private readonly IConfiguration _config = config;

    public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto)
    {
        var roleString = dto.Role ?? "Employee";

        if (!Enum.TryParse<UserRole>(roleString, true, out var role))
            role = UserRole.Employee;

        var user = new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = role,
            FarmId = null
        };

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
    var keyString = _config["Jwt:Key"]
        ?? throw new Exception("Jwt:Key not configured.");

    if (keyString.Length < 32)
        throw new Exception("Jwt:Key must be at least 32 characters long.");

    var key = Encoding.UTF8.GetBytes(keyString);

    var expiryMinutesRaw = _config["Jwt:ExpiryMinutes"];
    var expiryMinutes = int.TryParse(expiryMinutesRaw, out var minutes) && minutes > 0
        ? minutes
        : 480; // fallback: 8 horas

    var expiresAt = DateTime.UtcNow.AddMinutes(expiryMinutes);


    var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role.ToString()), 
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    if (user.FarmId.HasValue)
    {
        claims.Add(new Claim("farmId", user.FarmId.Value.ToString()));
    }

    var creds = new SigningCredentials(
        new SymmetricSecurityKey(key),
        SecurityAlgorithms.HmacSha256
    );

    var token = new JwtSecurityToken(
        issuer: _config["Jwt:Issuer"],
        audience: _config["Jwt:Audience"],
        claims: claims,
        expires: expiresAt,
        signingCredentials: creds
    );

    return new AuthResponseDto
    {
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Role = user.Role.ToString(),
        UserId = user.Id,
        FarmId = user.FarmId,
        ExpiresAt = expiresAt
    };
}

}