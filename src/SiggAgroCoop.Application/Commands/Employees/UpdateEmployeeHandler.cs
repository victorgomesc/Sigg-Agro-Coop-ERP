using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Employees;

public class UpdateEmployeeHandler(IEmployeeRepository repo) : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IEmployeeRepository _repo = repo;

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repo.GetByIdAsync(request.Id);
        if (employee is null) return false;

        employee.Name = request.Name;
        employee.Role = request.Role;
        employee.DocumentId = request.DocumentId;
        employee.SetUpdatedNow();

        await _repo.UpdateAsync(employee);
        return true;
    }
}
