using TinyUrl.Core;
using Base62;

namespace TinyUrl.EntityFrameworkCore;

public class TinyUrlGenerator:ITinyUrlGenerator
{

    private readonly ITinyUrlRepository<TinyUrlEntity> repository;

    public TinyUrlGenerator(Core.ITinyUrlRepository<TinyUrlEntity> repository)
    {
        this.repository = repository;
    }



    /// <summary>
    /// 直接将长链先MurmurHash再Base62位
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<string> GenerateAsync(string url)
    {
        
        var tinyUrl =  url.MurmurHash_32bit().ToBase62();

        var r = await repository.SaveAsync(url, tinyUrl);
        
        return r.IsSuccess?tinyUrl:throw new Exception(r.Message);

    }
}