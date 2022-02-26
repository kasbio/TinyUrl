using System.ComponentModel.DataAnnotations.Schema;

namespace TinyUrl.Core;

public class TinyUrlBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string OriginalUrl { get; set; }

    public string ShortUrl { get; set; }
}