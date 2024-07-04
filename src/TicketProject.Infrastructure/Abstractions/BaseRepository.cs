using Microsoft.EntityFrameworkCore;
using TicketProject.Domain.Abstractions;
using TicketProject.Domain.Contracts.Repositories;
using TicketProject.Infrastructure.Data;

namespace TicketProject.Infrastructure.Abstractions;

public class BaseRepository<TEntity>(TicketContext context) : IBaseRepository<TEntity>
    where TEntity : Entity
{
    public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
    {
        context
            .Set<TEntity>()
            .Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        context
            .Set<TEntity>()
            .Update(entity);
        await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        TEntity? entity = await context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return entity;
    }
}