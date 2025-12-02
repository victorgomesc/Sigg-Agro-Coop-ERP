using MediatR;

namespace SiggAgroCoop.Application.Commands.FieldLifecycle;

public record FinishHarvestCommand(Guid FieldId) : IRequest<bool>;
