using MediatR;
using SiggAgroCoop.Application.DTOs.Employees;

namespace SiggAgroCoop.Application.Queries.Employees;

public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;
