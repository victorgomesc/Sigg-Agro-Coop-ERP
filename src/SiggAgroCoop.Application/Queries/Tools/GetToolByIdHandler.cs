using MediatR;
using SiggAgroCoop.Application.DTOs.Tools;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Tools;

public class GetToolByIdHandler : IRequestHandler<GetToolByIdQuery, ToolDto?>
{
    private readonly IToolRepository _repo;

    public GetToolByIdHandler(IToolRepository repo)
    {
        _repo = repo;
    }

    public async Task<ToolDto?> Handle(GetToolByIdQuery request, CancellationToken cancellationToken)
    {
        var tool = await _repo.GetByIdAsync(request.Id);
        if (tool is null) return null;

        return new ToolDto(
            tool.Id,
            tool.Name,
            tool.Description,
            tool.AcquisitionDate,
            tool.EmployeeId
        );
    }
}
