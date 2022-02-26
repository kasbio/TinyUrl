using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Core;
using static TinyUrl.Test.UnitTest1;

namespace TinyUrl.Test
{


    class TinyUrlQueryTest<T> : ITinyUrlQuery<T> where T : TinyUrlBase
    {


        Dictionary<string, string> urls = new Dictionary<string, string>()
            {
                  {"/abc?id=123","https://baidu.com"}
            };

        public Task<T> FindAsync(string url)
        {
            if (urls.ContainsKey(url))
            {
                var u = urls[url];
                var t = new TinyUrlBase()
                {
                    Id = 0,
                    OriginalUrl = u,
                    ShortUrl = u
                };
                return Task.FromResult<T>((T)t);
            }

            return Task.FromResult<T>(null);
        }
    }

    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

 
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped(typeof(ITinyUrlQuery<>), typeof(TinyUrlQueryTest<>));

            services.Configure<TinyUrlRedirectOption>(o => {
                o.Is301 = false;
            });
        }

 
        public void Configure(IApplicationBuilder app)
        {
            app.UseTinyUrlRedirect();
        }
    }
}
