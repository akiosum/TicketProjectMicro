using Microsoft.EntityFrameworkCore;
using TicketProject.Domain.Entities;

namespace TicketProject.Infrastructure.Data;

public class TicketContext(DbContextOptions<TicketContext> options) :
    DbContext(options)
{
    public DbSet<Ticket> Ticket { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketContext).Assembly);
    }
}