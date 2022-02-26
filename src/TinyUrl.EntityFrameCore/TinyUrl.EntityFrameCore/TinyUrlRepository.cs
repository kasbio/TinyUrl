using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Core;

namespace TinyUrl.EntityFrameworkCore
{
    public class TinyUrlRepository: ITinyUrlRepository<TinyUrlEntity>
    {
        private readonly TinyUrlDbContext _context;

        public TinyUrlRepository(TinyUrlDbContext context)
        {
            _context = context;
        }

        public async Task<RepositoryResult<TinyUrlEntity>> SaveAsync(string originalUrl, string url)
        {
            try
            {
                TinyUrlEntity entity = new TinyUrlEntity();
                entity.OriginalUrl = originalUrl;
                entity.ShortUrl = url;
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                return RepositoryResult<TinyUrlEntity>.Success(entity);
            }
            catch (Exception e)
            {

                return RepositoryResult<TinyUrlEntity>.Fail(e.Message);
            }
            

        }
    }
}
