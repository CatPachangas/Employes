using Employees.Domain.Models;

namespace Employees.Infraestructure.Repository
{
    /// <summary>
    ///
    /// </summary>
    public interface IEmployeesRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Employee>> GetAllEmployees();
    }
}