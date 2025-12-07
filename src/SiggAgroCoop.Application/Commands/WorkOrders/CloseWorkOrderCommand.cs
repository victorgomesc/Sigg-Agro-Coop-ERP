using MediatR;

namespace SiggAgroCoop.Application.Commands.WorkOrders;

public record CloseWorkOrderCommand(Guid Id) : IRequest<bool>;
