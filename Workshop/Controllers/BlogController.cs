using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Workshop.Repositories;
using Workshop.Settings;

namespace Workshop.Controllers
{
    [Route("api/blog")]
    public class BlogController : ControllerBase
    {
        public BlogController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("MVC is working !!!");
        }
    }
}
