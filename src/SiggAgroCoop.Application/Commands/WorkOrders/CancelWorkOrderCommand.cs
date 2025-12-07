using MediatR;

namespace SiggAgroCoop.Application.Commands.WorkOrders;

public record CancelWorkOrderCommand(Guid Id) : IRequest<bool>;
