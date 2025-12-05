using MediatR;
using SiggAgroCoop.Application.DTOs.Tools;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Queries.Tools;

public class GetToolsByEmployeeHandler :
    IRequestHandler<GetToolsByEmployeeQuery, IEnumerable<ToolDto>>
{
    private readonly IToolRepository _repo;

    public GetToolsByEmployeeHandler(IToolRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ToolDto>> Handle(GetToolsByEmployeeQuery request, CancellationToken cancellationToken)
    {
        var tools = await _repo.GetByEmployeeAsync(request.EmployeeId);

        return tools.Select(t =>
            new ToolDto(t.Id, t.Name, t.Description, t.AcquisitionDate, t.EmployeeId)
        );
    }
}
