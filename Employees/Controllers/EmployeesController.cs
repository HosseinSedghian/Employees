using Microsoft.AspNetCore.Mvc;
using Employees.Contracts;
using Employees.Services;
using System.Text.Json;
using Newtonsoft.Json;
using Employees.Models;
namespace Employees.Controllers
{
    [ApiController]
    [Route("Employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        //----------------------------
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeRequest request)
        {
            Employee employee = MapRequestToEmployee(request);
            _employeeService.Create(ref employee);
            return Ok(MapEmployeeToResponse(employee));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = _employeeService.Get(id);
            if(employee == null)
            {
                var response = new { Response = $"Employee with Id {id} does not exist" };
                return NotFound(response);
            }
            return Ok(MapEmployeeToResponse(employee));
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee(int id, [FromBody] JsonElement json)
        {
            Employee employee = _employeeService.Get(id);
            if (employee == null)
            {
                var response = new { Response = $"Employee with Id {id} does not exist" };
                return NotFound(response);
            }
            string text = json.ToString();
            JsonConvert.PopulateObject(text, employee);
            _employeeService.Update(employee);
            return Ok(MapEmployeeToResponse(employee));
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = _employeeService.Get(id);
            if (employee == null)
            {
                var response = new { Response = $"Employee with Id {id} does not exist" };
                return NotFound(response);
            }
            _employeeService.Delete(employee);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            List<EmployeeResponse> allemployees = _employeeService.GetAll().Select(e => MapEmployeeToResponse(e)).ToList();
            if (allemployees.Count == 0)
            {
                var response = new { Response = "The employees table is empty" };
                return NotFound(response);
            }
            return Ok(allemployees);
        }
        public IActionResult DeleteAllEmployees()
        {
            _employeeService.DeleteAll();
            var response = new { Response = "The employees table is empty" };
            return Ok(response);
        }
        private EmployeeResponse MapEmployeeToResponse(Employee employee) =>
            new EmployeeResponse(employee.Id, employee.Name, employee.Family, employee.Email);
        private Employee MapRequestToEmployee(EmployeeRequest request) =>
            new Employee() { Name = request.Name, Family = request.Family, Email = request.Email, Password = request.Password};
    }
}
