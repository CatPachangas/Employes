using Employees.Domain.Models;
using Employees.Domain.Requests;
using Employees.Domain.Responses;
using Employees.Infraestructure.Repository;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Employees.Services.Queries.GetAllEmployees
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesRequest, GetAllEmployeesResponse>
    {

        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeesRepository"></param>
        public GetAllEmployeesHandler(IEmployeesRepository employeesRepository, IMemoryCache memoryCache)
        {
            _employeesRepository = employeesRepository;
            _memoryCache = memoryCache;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetAllEmployeesResponse> Handle(GetAllEmployeesRequest request, CancellationToken cancellationToken)
        {
            GetAllEmployeesResponse employeesList;

            var cacheName = "employeesList";
            var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1));

            if (_memoryCache.TryGetValue(cacheName, out List<Employee> result))
            {
                employeesList = new GetAllEmployeesResponse
                {
                    Employees = result
                };

                return employeesList;
            }


            var response = await _employeesRepository.GetAllEmployees();

            if (response.Count != 0)
            {
                _memoryCache.Set(cacheName, response, cacheOptions);
            }

            employeesList = new GetAllEmployeesResponse
            {
                Employees = response
            };

            return employeesList;
        }
    }
}

