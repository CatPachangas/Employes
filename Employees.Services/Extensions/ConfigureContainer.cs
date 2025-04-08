using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Employees.Services.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigureContainer
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }

    }
}
