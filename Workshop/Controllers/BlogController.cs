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
        private readonly ILogger<BlogController> _logger;
        private readonly IBlogRepository _blogRepository;

        public BlogController(IOptions<BlogSettings> blogOptions, ILogger<BlogController> logger, IBlogRepository blogRepository)
        {
            _blogOptions = blogOptions;
            _logger = logger;
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation($"{_blogOptions.Value.Title} - {_blogOptions.Value.BlogType}");
            return Ok(_blogRepository.Read());
        }
    }
}
