using MediatR;
using SiggAgroCoop.Application.DTOs.Harvests;

namespace SiggAgroCoop.Application.Queries.Harvests;

public record GetHarvestsByFieldQuery(Guid FieldId) 
    : IRequest<IEnumerable<HarvestHistoryDto>>;
