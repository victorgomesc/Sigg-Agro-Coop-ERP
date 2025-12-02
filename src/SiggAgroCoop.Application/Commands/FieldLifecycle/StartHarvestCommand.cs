using MediatR;

namespace SiggAgroCoop.Application.Commands.FieldLifecycle;

public record StartHarvestCommand(
    Guid FieldId,
    Guid CropId,
    DateTime HarvestDate,
    double? MoisturePercentage,
    string? Notes
) : IRequest<bool>;
