using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Model
{
    [Index("Hash", IsUnique = true)]
    public class TinyUrlEntity
    {

        public int Id { get; set; }

        public string Lurl { get; set; }


        public string Surl { get; set; }


        public DateTime CreateDateTime { get; set; }

        public DateTime ExpriedDateTime { get; set; }

    }

 

}
