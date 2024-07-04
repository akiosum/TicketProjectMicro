using TicketProject.Domain.Abstractions;

namespace TicketProject.Domain.Contracts.Repositories;

public interface IBaseRepository<TEntity> : IRepository
    where TEntity : Entity
{
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken);
}