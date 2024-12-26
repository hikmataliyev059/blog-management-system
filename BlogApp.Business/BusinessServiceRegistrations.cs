using System.Reflection;
using BlogApp.Business.Services.Impl;
using BlogApp.Business.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Business;

public static class BusinessServiceRegistrations
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BusinessServiceRegistrations));
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddControllers().AddFluentValidation(cfg =>
            cfg.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
    }
}