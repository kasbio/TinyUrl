using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;
using TinyUrl.Core;
using Xunit;

namespace TinyUrl.Test
{
    public class UnitTest1
    {

        [Fact]
        public async Task TinyUrl_NotFoundUrl()
        {
            var host =await CreateServer();
            var client =  host.GetTestClient();
            var rep = await client.GetAsync("/test?id=test");

            Assert.Equal(System.Net.HttpStatusCode.NotFound, rep.StatusCode);
        }

        [Fact]
        public async Task TinyUrl_FoundUrl()
        {
            var host = await CreateServer();
            var client = host.GetTestClient();
            var rep = await client.GetAsync("/abc?id=123");

            Assert.Equal(System.Net.HttpStatusCode.Redirect, rep.StatusCode);
            Assert.Equal("https://baidu.com", rep.Headers.Location.OriginalString);
        }

        private async Task<IHost> CreateServer()
        {

            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TestStartup>();
                    webBuilder.UseTestServer();
                });

            IHost host = await builder.StartAsync();

            return host;



        }


    }
}