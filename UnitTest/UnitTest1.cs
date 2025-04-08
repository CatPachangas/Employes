using Employees.API.Controllers;
using Employees.Domain.Models;
using Employees.Domain.Requests;
using Employees.Domain.Responses;
using Employees.Infraestructure.Repository;
using Employees.Services.Queries.GetAllEmployees;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Reflection.Metadata;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetAllEmployeesController()
        {

            GetAllEmployeesResponse response = new GetAllEmployeesResponse()
            {
                Employees = new List<Employee>()
            {
                    new Employee
                    {
                        Age= 22,
                        AnnualSalary= 220000,
                        Id =1,
                        Image="",
                        Name="Juan",
                        Salary=11000
                    },
                    new Employee
                    {
                        Age= 22,
                        AnnualSalary= 220000,
                        Id =21,
                        Image="",
                        Name="Pedro",
                        Salary=11000
                    }
                }
            };

            var _mockMediatr = new Mock<IMediator>();
            var _mockRepo = new Mock<IEmployeesRepository>();
            var _mockCache = new Mock<IMemoryCache>();
            var _handler = new GetAllEmployeesHandler(_mockRepo.Object, _mockCache.Object);

            _mockMediatr.Setup(m => m.Send(It.IsAny<GetAllEmployeesResponse>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);
            _mockRepo.Setup(m=>m.GetAllEmployees()).ReturnsAsync(response.Employees);

            var mockCacheEntry = new Mock<ICacheEntry>();
            _mockCache.Setup(x => x.CreateEntry(It.IsAny<object>()))
                    .Returns(mockCacheEntry.Object);

            var result = await _handler.Handle(new GetAllEmployeesRequest(), new CancellationToken());


            Assert.NotNull(result.Employees);
            Assert.Equal(2, result.Employees.Count);

        }
    }
}