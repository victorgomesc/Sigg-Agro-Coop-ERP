using MediatR;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Employees;

public class CreateEmployeeHandler(IEmployeeRepository repo) : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _repo = repo;

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Name = request.Name,
            Role = request.Role,
            DocumentId = request.DocumentId
        };

        await _repo.AddAsync(employee);
        return employee.Id;
    }
}
