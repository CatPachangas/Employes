using Employees.Domain.Models;
using Employees.Domain.Requests;
using Employees.Domain.Responses;
using Employees.Infraestructure.Repository;
using MediatR;

namespace Employees.Services.Queries.GetEmployeeById
{
    /// <summary>
    ///
    /// </summary>
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IMediator _mediator;

        /// <summary>
        ///
        /// </summary>
        /// <param name="employeesRepository"></param>
        public GetEmployeeByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var resp = await _mediator.Send(new GetAllEmployeesRequest(), default);

            var response = await GetEmployeeById(request.Id, resp);

            GetEmployeeByIdResponse employee;

            response.AnnualSalary = CalculateAnnualSalary(response.Salary);

            employee = new GetEmployeeByIdResponse
            {
                Employee = response
            };

            return employee;
        }

        private double CalculateAnnualSalary(double salary)
        {
            var annualSalary = salary * 12;

            return annualSalary;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Employee> GetEmployeeById(int id, GetAllEmployeesResponse data)
        {
            var employee = data.Employees.Find(x => x.Id == id);
            return employee;
        }
    }
}