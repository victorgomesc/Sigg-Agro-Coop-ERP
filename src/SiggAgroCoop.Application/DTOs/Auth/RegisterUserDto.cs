namespace SiggAgroCoop.Application.DTOs.Auth;

public class RegisterUserDto
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Role { get; set; } = "Employee"; // Admin|Manager|Employee
}
