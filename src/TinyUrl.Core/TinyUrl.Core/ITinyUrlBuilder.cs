using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Core
{
    public interface ITinyUrlBuilder 
    {

        IServiceCollection Services { get; set; }

    }


    public class DefaultTinyUrlBuilder : ITinyUrlBuilder
    {
        public IServiceCollection Services { get; set; }

        public DefaultTinyUrlBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }

    
}
