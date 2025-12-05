using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Tools;

public class UpdateToolHandler(IToolRepository toolRepo, IEmployeeRepository employeeRepo) : IRequestHandler<UpdateToolCommand, bool>
{
    private readonly IToolRepository _toolRepo = toolRepo;
    private readonly IEmployeeRepository _employeeRepo = employeeRepo;

    public async Task<bool> Handle(UpdateToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await _toolRepo.GetByIdAsync(request.Id);
        if (tool is null) return false;

        var employee = await _employeeRepo.GetByIdAsync(request.EmployeeId);
        if (employee is null) return false;

        tool.Name = request.Name;
        tool.Description = request.Description;
        tool.AcquisitionDate = request.AcquisitionDate;
        tool.EmployeeId = request.EmployeeId;
        tool.SetUpdatedNow();

        await _toolRepo.UpdateAsync(tool);
        return true;
    }
}
