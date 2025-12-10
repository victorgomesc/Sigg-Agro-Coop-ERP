using SiggAgroCoop.Application.DTOs.Auth;

namespace SiggAgroCoop.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto);
    Task<AuthResponseDto> LoginAsync(LoginDto dto);
}
