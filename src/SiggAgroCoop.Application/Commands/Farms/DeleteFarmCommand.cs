using MediatR;

namespace SiggAgroCoop.Application.Commands.Farms;

public record DeleteFarmCommand(Guid Id) : IRequest<bool>;
