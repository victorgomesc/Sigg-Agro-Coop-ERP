using MediatR;
using SiggAgroCoop.Application.DTOs.Crops;

namespace SiggAgroCoop.Application.Queries.Crops;

public record GetCropByIdQuery(Guid Id) : IRequest<CropDto?>;
