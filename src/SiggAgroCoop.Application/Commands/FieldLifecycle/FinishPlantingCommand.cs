using MediatR;

namespace SiggAgroCoop.Application.Commands.FieldLifecycle;

public record FinishPlantingCommand(Guid FieldId) : IRequest<bool>;
