using MediatR;
using SiggAgroCoop.Application.DTOs.Employees;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Employees;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IEmployeeRepository _repo;

    public GetAllEmployeesHandler(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _repo.GetAllAsync();
        return employees.Select(e => new EmployeeDto(e.Id, e.Name, e.Role, e.DocumentId));
    }
}
