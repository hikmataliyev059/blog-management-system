using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;

namespace BlogApp.DAL.Repositories.Impl;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(BlogAppDbContext context) : base(context)
    {
    }
}