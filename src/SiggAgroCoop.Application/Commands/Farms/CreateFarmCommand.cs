using MediatR;

namespace SiggAgroCoop.Application.Commands.Farms;

public record CreateFarmCommand(string Name, string Location) : IRequest<Guid>;
