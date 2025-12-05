using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Employees;

public class DeleteEmployeeHandler(IEmployeeRepository repo) : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeeRepository _repo = repo;

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repo.GetByIdAsync(request.Id);
        if (employee is null) return false;

        await _repo.DeleteAsync(request.Id);
        return true;
    }
}
