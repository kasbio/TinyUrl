using System.Data.HashFunction.MurmurHash;
using System.Text;

namespace TinyUrl.Core;

public static class MurmurHash
{
    static MurmurHash3Config config_32 = new MurmurHash3Config()
    {
        HashSizeInBits=32 
    } ;

    static MurmurHash3Config config_64 = new MurmurHash3Config()
    {
        HashSizeInBits = 64
    };

    public static string Getby32bit(int id)
    {
        return Get(id,config_32);
    }

    public static string Getby32bit(string id)
    {
        return Get(id, config_32);
    }

    public static string Getby64bit(int id)
    {
        return Get(id, config_64);
    }

    public static string Getby64bit(string id)
    {
        return Get(id, config_64);
    }
    static string Get(int id,IMurmurHash3Config config)
    {
        var hash = MurmurHash3Factory.Instance.Create(config);
        var b = Encoding.UTF8.GetBytes(id.ToString());
        return hash.ComputeHash(b).AsHexString();
    }


    static string Get(string id, IMurmurHash3Config config)
    {
        var hash = MurmurHash3Factory.Instance.Create(config);
        var b = Encoding.UTF8.GetBytes(id);
        return hash.ComputeHash(b).AsHexString();
    }



}

public static class StringExtension
{
    public static string MurmurHash_32bit(this string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        return MurmurHash.Getby32bit(s);
    }
    
    public static string MurmurHash_64bit(this string s)
    {        
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        return MurmurHash.Getby64bit(s);
    }
}