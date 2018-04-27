using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Workshop.Entities;
using Workshop.Repositories;
using Workshop.Settings;

namespace Workshop.Controllers
{
    [Route("api/blog")]
    public class BlogController : Controller
    {
        private readonly IOptions<BlogSettings> _blogOptions;

        public BlogController(IOptions<BlogSettings> blogOptions)
        {
            _blogOptions = blogOptions;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"{_blogOptions.Value.Title} - {_blogOptions.Value.BlogType}");
        }
    }
}
