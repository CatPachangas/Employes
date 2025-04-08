using Employees.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllEmployeesResponse
    {
        public List<Employee> Employees { get; set; }
    }
}
