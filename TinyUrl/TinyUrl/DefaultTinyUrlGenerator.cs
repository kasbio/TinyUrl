using TinyUrl.Core;
using Base62;

namespace TinyUrl;

public class DefaultTinyUrlGenerator:ITinyUrlGenerator
{

     



    /// <summary>
    /// ֱ�ӽ�������MurmurHash��Base62λ
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<string> GenerateAsync(string url)
    {
        
        var tinyUrl =  url.MurmurHash_32bit().ToBase62();

        return tinyUrl;

    }
}