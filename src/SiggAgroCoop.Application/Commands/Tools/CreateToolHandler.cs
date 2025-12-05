using MediatR;
using SiggAgroCoop.Domain.Entities;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Tools;

public class CreateToolHandler(IToolRepository toolRepo, IEmployeeRepository employeeRepo) : IRequestHandler<CreateToolCommand, Guid>
{
    private readonly IToolRepository _toolRepo = toolRepo;
    private readonly IEmployeeRepository _employeeRepo = employeeRepo;

    public async Task<Guid> Handle(CreateToolCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepo.GetByIdAsync(request.EmployeeId);
        if (employee is null)
            throw new ArgumentException("Employee not found.");

        var tool = new Tool
        {
            Name = request.Name,
            Description = request.Description,
            AcquisitionDate = request.AcquisitionDate,
            EmployeeId = request.EmployeeId
        };

        await _toolRepo.AddAsync(tool);
        return tool.Id;
    }
}
