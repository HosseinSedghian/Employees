using Microsoft.AspNetCore.Mvc;
using Employees.Models;
namespace Employees.Controllers
{
    [ApiController]
    [Route("/status")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            var status = new { Status = "OK" };
            return Ok(status);
        }
    }
}
