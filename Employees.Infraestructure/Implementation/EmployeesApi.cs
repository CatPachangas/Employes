using Employees.Domain.Models;
using Employees.Infraestructure.Repository;
using Newtonsoft.Json;
using RestSharp;

namespace Employees.Infraestructure.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeesApi : IEmployeesRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllEmployees()
        {
            var client = new RestClient("https://dummy.restapiexample.com/");
            var request = new RestRequest("api/v1/employees");
            var response = await client.ExecuteAsync<dynamic>(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<Employee>() { };
            }

            dynamic obj = JsonConvert.DeserializeObject(response.Content);
            var data = obj?.data;

            var formattedList = data?.ToString().Trim().TrimStart('{').TrimEnd('}');
            var list = JsonConvert.DeserializeObject<List<Employee>>(formattedList);

            return list;
        }

    }
}
