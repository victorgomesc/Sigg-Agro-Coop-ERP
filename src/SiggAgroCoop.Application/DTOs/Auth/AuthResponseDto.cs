namespace SiggAgroCoop.Application.DTOs.Auth;

public class AuthResponseDto
{
    public string Token { get; set; } = default!;
    public string Role { get; set; } = default!;
    public Guid UserId { get; set; }
    public Guid? FarmId { get; set; }
}
