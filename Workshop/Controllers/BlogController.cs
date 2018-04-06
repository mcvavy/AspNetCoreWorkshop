using Microsoft.AspNetCore.Mvc;

namespace Workshop.Controllers
{
    [Route("api/blog")]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("MVC is working !!!");
        }
    }
}
