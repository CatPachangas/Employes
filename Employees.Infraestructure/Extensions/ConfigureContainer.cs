using Employees.Infraestructure.Implementation;
using Employees.Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Infraestructure.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigureContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeesRepository, EmployeesApi>();

            return services;
        }
    }
}
