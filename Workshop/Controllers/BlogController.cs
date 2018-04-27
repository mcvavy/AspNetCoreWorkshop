using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Semantics;
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

        /// <summary>
        /// Get all blog entries
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Blog>), 200)]
        public IActionResult Get()
        {
            _logger.LogInformation($"{_blogOptions.Value.Title} - {_blogOptions.Value.BlogType}");
            return Ok(_blogRepository.Read());
        }

        /// <summary>
        /// Create new blog entry
        /// </summary>
        /// <param name="blog"></param>
        /// <response code="200">Returns created blog entry</response>
        /// <response code="400">When request is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(Blog), 200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public IActionResult Post([FromBody] Blog blog)
        {
            return Ok(_blogRepository.Create(blog));
        }
    }
}
