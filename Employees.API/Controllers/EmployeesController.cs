using Employees.Domain.Requests;
using Employees.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
            //_mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // POST api/<EmployeesController>
        [HttpPost]
        [Route("GetAllEmployees")]
        public async Task<ActionResult<GetAllEmployeesResponse>> GetAllEmployes([FromBody] GetAllEmployeesRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("GetEmployeeById")]
        public async Task<ActionResult<GetEmployeeByIdResponse>> GetEmployeeById([FromBody] GetEmployeeByIdRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
