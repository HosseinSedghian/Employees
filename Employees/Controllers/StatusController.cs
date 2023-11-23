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
            Status status = new Status();
            status.APIStatus = "OK";
            return Ok(status);
        }
    }
}
