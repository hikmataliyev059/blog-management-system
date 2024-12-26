using System.Linq.Expressions;
using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    DbSet<TEntity> Table { get; }

    Task<TEntity?> GetByIdAsync(int id);

    IQueryable<TEntity> GetAllAsync();

    Task AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
    
    Task SoftDeleteAsync(TEntity entity);

    Task<int> SaveChangesAsync();

    IQueryable<TEntity> FindAllAsync(Expression<Func<TEntity, bool>> expression);
}