using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Core;

namespace TinyUrl
{
    public static class ServiceExtension
    {
        public static ITinyUrlBuilder AddTinyUrlGenerator(this IServiceCollection services)
        {
            DefaultTinyUrlBuilder builder = new DefaultTinyUrlBuilder(services);
            var s= builder.Services;
            services.AddScoped<ITinyUrlGenerator, DefaultTinyUrlGenerator>();
            return builder;
        }

    }
}
