using TicketProject.Domain.Contracts.Repositories;
using TicketProject.Domain.Entities;
using TicketProject.Infrastructure.Abstractions;
using TicketProject.Infrastructure.Data;

namespace TicketProject.Infrastructure.Repositories;

public class TicketRepository
    (TicketContext context) :
    BaseRepository<Ticket>(context), 
    ITicketRepository
{
    
}