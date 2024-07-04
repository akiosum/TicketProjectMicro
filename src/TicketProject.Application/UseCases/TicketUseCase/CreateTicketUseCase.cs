using EventMessages.Bus.Contracts;
using FastResults.Results;
using Mapster;
using MediatR;
using TicketProject.Application.Abstractions;
using TicketProject.Application.Requests.Ticket;
using TicketProject.Domain.Contracts.Repositories;

namespace TicketProject.Application.UseCases.TicketUseCase;

public class CreateTicketUseCase(
    ISender sender,
    ITicketRepository ticketRepository,
    IEventBus eventBus) :
    BaseUseCase<CreateTicketRequest>(sender)
{
    public override async Task<BaseResult> Handle(
        CreateTicketRequest request,
        CancellationToken cancellationToken)
    {
        var ticket = request.Adapt<Domain.Entities.Ticket>();

        await ticketRepository.Create(ticket, cancellationToken);

        return BaseResult.Sucess();
    }
}