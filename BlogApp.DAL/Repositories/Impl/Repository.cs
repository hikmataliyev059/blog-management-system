using System.Linq.Expressions;
using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories.Impl;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly BlogAppDbContext _context;

    public Repository(BlogAppDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public IQueryable<TEntity> GetAllAsync()
    {
        return Table.Where(x => !x.IsDeleted).AsQueryable();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }

    public Task UpdateAsync(TEntity entity)
    {
        Table.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        Table.Remove(entity);
        return Task.CompletedTask;
    }

    public Task SoftDeleteAsync(TEntity entity)
    {
        entity.IsDeleted = true;
        Table.Update(entity);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public IQueryable<TEntity> FindAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        return Table.Where(expression);
    }
}