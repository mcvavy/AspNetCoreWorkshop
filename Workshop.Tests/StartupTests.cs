using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Workshop.Tests
{
    class StartupTests
    {
        [Test]
        public async Task ShouldHaveSwaggerEndpoint()
        {
            var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            using (var client = testServer.CreateClient())
            {
                var response = await client.GetAsync("/swagger/v1/swagger.json");

                response.EnsureSuccessStatusCode();

                response.Content.Headers.ContentType.MediaType.Should().Be("application/json");
            }
        }
    }
}
