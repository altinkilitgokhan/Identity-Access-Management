using System.Reflection;
using IAM.Application.Helpers.JwtHelpers;
using IAM.Application.Interfaces;
using IAM.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IAM.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IJwtUtils, JwtUtils>();
            return services;
        }
    }
}
