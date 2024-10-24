using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories;

public interface IRepository<TEntity, TId> where TEntity : Entity<TId>, new()
{
    List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, bool enableAutoInclude = true);
    TEntity? GetById(TId id);
    TEntity? Update(TEntity entity);
    TEntity? Add(TEntity entity);
    TEntity? Remove(TEntity entity);
}
