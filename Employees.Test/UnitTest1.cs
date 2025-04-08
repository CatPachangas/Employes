using Employees.API.Controllers;
using Employees.Domain.Responses;
using MediatR;
using Moq;
using Xunit;

namespace Employees.Test
{
    public class EmployeeApiClientTests
    {
        [Fact]
        public async Task GetAllEmployeesController()
        {
            GetAllEmployeesResponse response = new GetAllEmployeesResponse()
            {
                Employees = new List<Domain.Models.Employee>()
            {
                    new Domain.Models.Employee
                    {
                        Age= 22,
                        AnnualSalary= 220000,
                        Id =1,
                        Image="",
                        Name="Juan",
                        Salary=11000
                    }
                }
            };

            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m =>m.Send(It.IsAny<GetAllEmployeesResponse>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

            EmployeesController controller = new EmployeesController(mockMediator.Object);
            var result = await controller.GetAllEmployes(new Domain.Requests.GetAllEmployeesRequest());   


            Assert.NotNull(result?.Value?.Employees);

        }
    }
}
