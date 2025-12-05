using SiggAgroCoop.Domain.Common;

namespace SiggAgroCoop.Domain.Entities;

public class Tool : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime AcquisitionDate { get; set; }

    // Relationship: which employee is responsible
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;
}
