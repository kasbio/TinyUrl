using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Core;

namespace TinyUrl.EntityFrameworkCore
{
    public class TinyUrlQuery : ITinyUrlQuery<TinyUrlEntity>
    {

        private readonly TinyUrlDbContext _context;

        public async Task<TinyUrlEntity> FindAsync(string url)
        {
            //或者可以从Redis中获取
            var entity = await _context.Urls.FirstOrDefaultAsync(o => o.ShortUrl == url);
            return entity;

        }
    }
}
