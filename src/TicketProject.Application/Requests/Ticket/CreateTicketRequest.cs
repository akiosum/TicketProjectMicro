using TicketProject.Application.Abstractions.Contracts;

namespace TicketProject.Application.Requests.Ticket;

public record CreateTicketRequest(
    string Title,
    string Description,
    DateTime ResponseDate) : IRequestUseCase;