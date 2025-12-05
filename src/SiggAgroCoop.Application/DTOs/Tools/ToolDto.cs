namespace SiggAgroCoop.Application.DTOs.Tools;

public record ToolDto(
    Guid Id,
    string Name,
    string Description,
    DateTime AcquisitionDate,
    Guid EmployeeId
);
