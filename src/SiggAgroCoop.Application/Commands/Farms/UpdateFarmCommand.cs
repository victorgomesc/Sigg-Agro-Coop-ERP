using MediatR;

namespace SiggAgroCoop.Application.Commands.Farms;

public record UpdateFarmCommand(Guid Id, string Name, string Location) : IRequest<bool>;
