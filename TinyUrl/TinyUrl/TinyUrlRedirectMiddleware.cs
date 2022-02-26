using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Core;

namespace TinyUrl
{

    public class TinyUrlRedirectOption
    {
        public bool Is301 { get; set; }
    }

    internal class TinyUrlRedirectMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _services;
        private readonly TinyUrlRedirectOption _option;
        private readonly ILogger<TinyUrlRedirectMiddleware> _logger;

        public TinyUrlRedirectMiddleware(RequestDelegate next,
             IOptions<TinyUrlRedirectOption> options,
            ILogger<TinyUrlRedirectMiddleware> logger, IServiceProvider services)
        {
            _next = next;
           
            _option = options?.Value ?? throw new ArgumentNullException(nameof(TinyUrlRedirectOption));
            _logger = logger;
            _services = services;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using var scope = _services.CreateScope();
            var query = scope.ServiceProvider.GetRequiredService<ITinyUrlQuery<TinyUrlBase>>();
            var path = GetPathAndQuery(context);
            var entity = await query.FindAsync(path);
            if (entity is null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"No Found Url : {path}");
                return;
            }

            context.Response.Redirect(entity.OriginalUrl, _option.Is301);
        }

        private string GetPathAndQuery(HttpContext context)
        {
            return $"{context.Request.Path}{context.Request.QueryString}";
        }
    }

    public static class TinyUrlMiddlewareExtension
    {
        /// <summary>
        /// 是否启用短链接跳转
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseTinyUrlRedirect(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<TinyUrlRedirectMiddleware>();
            return builder;
        }
    }
}
