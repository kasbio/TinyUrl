using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Core;

namespace TinyUrl.EntityFrameworkCore
{
    public static class ServiceExtension
    {
        public static ITinyUrlBuilder AddEntityFramework(this ITinyUrlBuilder services, Action<DbContextOptionsBuilder> optionsAction)
        {
            var s = services.Services;
            s.AddScoped(typeof(ITinyUrlQuery<>),typeof(DefaultTinyUrlQuery<>));
            s.AddScoped<ITinyUrlQuery<TinyUrlEntity>, TinyUrlQuery>();
            s.AddScoped<ITinyUrlRepository<TinyUrlEntity>, TinyUrlRepository>();
            s.AddDbContext<TinyUrlDbContext>(optionsAction);
            return services;
        }

    }
}
