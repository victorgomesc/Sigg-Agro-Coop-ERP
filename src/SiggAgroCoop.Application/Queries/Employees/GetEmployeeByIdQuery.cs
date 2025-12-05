using MediatR;
using SiggAgroCoop.Application.DTOs.Employees;

namespace SiggAgroCoop.Application.Queries.Employees;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<EmployeeDto?>;
