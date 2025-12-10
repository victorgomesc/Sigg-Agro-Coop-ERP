using SiggAgroCoop.Domain.Common;
using SiggAgroCoop.Domain.Enums;

namespace SiggAgroCoop.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;

    public UserRole Role { get; set; } = UserRole.Employee;
    public Guid? FarmId { get; set; }
    public Farm? Farm { get; set; }
}
