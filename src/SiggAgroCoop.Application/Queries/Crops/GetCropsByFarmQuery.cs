using MediatR;
using SiggAgroCoop.Application.DTOs.Crops;

namespace SiggAgroCoop.Application.Queries.Crops;

public record GetCropsByFarmQuery(Guid FarmId) : IRequest<IEnumerable<CropDto>>;
