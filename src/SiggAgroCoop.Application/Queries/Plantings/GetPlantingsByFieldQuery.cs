using MediatR;
using SiggAgroCoop.Application.DTOs.Plantings;

namespace SiggAgroCoop.Application.Queries.Plantings;

public record GetPlantingsByFieldQuery(Guid FieldId) 
    : IRequest<IEnumerable<PlantingHistoryDto>>;
