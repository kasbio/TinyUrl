namespace TinyUrl.Core;

public interface ITinyUrlGenerator
{
    /// <summary>
    /// 短链接生成器
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    Task<string> GenerateAsync(string url);


}