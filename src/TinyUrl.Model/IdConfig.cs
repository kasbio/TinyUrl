using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Model
{
    public  class IdConfig
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int Start { get; set; }

        public int End { get; set; }
 

        public DateTime CreateDateTime { get; set; }

        public string Seed { get; set; }
        
        

    }
}
