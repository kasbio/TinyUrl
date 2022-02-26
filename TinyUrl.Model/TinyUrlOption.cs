using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl
{
    public class TinyUrlOption
    {
        public TimeSpan DefaultExpired { get; set; }

        public string Prefix { get; set; }

        public int Increment { get; set; }

        public string Seed { get; set; }

    }
}
