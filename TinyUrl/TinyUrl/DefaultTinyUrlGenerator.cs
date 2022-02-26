using TinyUrl.Core;
using Base62;

namespace TinyUrl;

public class DefaultTinyUrlGenerator:ITinyUrlGenerator
{

     



    /// <summary>
    /// 直接将长链先MurmurHash再Base62位
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<string> GenerateAsync(string url)
    {
        
        var tinyUrl =  url.MurmurHash_32bit().ToBase62();

        return tinyUrl;

    }
}