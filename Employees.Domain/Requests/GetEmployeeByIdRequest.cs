using Employees.Domain.Responses;
using MediatR;

namespace Employees.Domain.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEmployeeByIdRequest : IRequest<GetEmployeeByIdResponse>
    {
        public int Id { get; set; }
    }
}
