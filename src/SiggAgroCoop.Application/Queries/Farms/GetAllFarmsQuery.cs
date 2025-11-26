using MediatR;
using SiggAgroCoop.Application.DTOs.Farms;

namespace SiggAgroCoop.Application.Queries.Farms;

public record GetAllFarmsQuery() : IRequest<IEnumerable<FarmDto>>;
