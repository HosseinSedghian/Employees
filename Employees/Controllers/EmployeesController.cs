using Microsoft.AspNetCore.Mvc;
using Employees.Contracts;
using Employees.Services;
using Employees.Models;
namespace Employees.Controllers
{
    [ApiController]
    [Route("/Employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeRequest request)
        {

        }
        private Employee MapRequest(EmployeeRequest request)
        {
            return new Employee(

                );
        }
    }
}
