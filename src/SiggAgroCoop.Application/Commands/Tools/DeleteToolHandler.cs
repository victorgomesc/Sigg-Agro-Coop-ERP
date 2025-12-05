using MediatR;
using SiggAgroCoop.Domain.Interfaces;

namespace SiggAgroCoop.Application.Commands.Tools;

public class DeleteToolHandler(IToolRepository repo) : IRequestHandler<DeleteToolCommand, bool>
{
    private readonly IToolRepository _repo = repo;

    public async Task<bool> Handle(DeleteToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await _repo.GetByIdAsync(request.Id);
        if (tool is null) return false;

        await _repo.DeleteAsync(request.Id);
        return true;
    }
}
