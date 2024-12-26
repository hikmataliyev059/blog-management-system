using BlogApp.DAL.Repositories.Impl;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.DAL;

public static class DalServiceRegistration
{
    public static void AddDalServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}