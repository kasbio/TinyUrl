using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Model
{
   public class TinyUrlForId
    {
        public int Id { get; set; }

        public string Lurl { get; set; }

        public string MD5 { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime Expired { get; set; }

    }
}
