namespace SiggAgroCoop.Application.DTOs.Employees;

public record EmployeeDto(
    Guid Id,
    string Name,
    string Role,
    string DocumentId
);
