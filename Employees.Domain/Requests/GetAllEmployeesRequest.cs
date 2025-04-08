using Employees.Domain.Responses;
using MediatR;

namespace Employees.Domain.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllEmployeesRequest : IRequest<GetAllEmployeesResponse>
    {
    }
}
