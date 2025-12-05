using MediatR;
using SiggAgroCoop.Application.DTOs.Employees;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Employees;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
{
    private readonly IEmployeeRepository _repo;

    public GetEmployeeByIdHandler(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public async Task<EmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _repo.GetByIdAsync(request.Id);
        if (employee is null) return null;

        return new EmployeeDto(employee.Id, employee.Name, employee.Role, employee.DocumentId);
    }
}
