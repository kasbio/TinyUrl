using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Core
{
    public interface ITinyUrlQuery<T> where T: TinyUrlBase
    {
        Task<T> FindAsync(string url);

     
    }

    public class DefaultTinyUrlQuery<T> : ITinyUrlQuery<T> where T : TinyUrlBase
    {
        public Task<T> FindAsync(string url)
        {
            return Task.FromResult<T>(default(T));
        }
    }
}
