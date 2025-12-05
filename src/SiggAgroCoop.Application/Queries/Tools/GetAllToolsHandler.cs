using MediatR;
using SiggAgroCoop.Application.DTOs.Tools;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Tools;

public class GetAllToolsHandler : IRequestHandler<GetAllToolsQuery, IEnumerable<ToolDto>>
{
    private readonly IToolRepository _repo;

    public GetAllToolsHandler(IToolRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ToolDto>> Handle(GetAllToolsQuery request, CancellationToken cancellationToken)
    {
        var tools = await _repo.GetAllAsync();
        return tools.Select(t =>
            new ToolDto(t.Id, t.Name, t.Description, t.AcquisitionDate, t.EmployeeId)
        );
    }
}
