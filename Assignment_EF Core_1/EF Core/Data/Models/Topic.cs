using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    internal class Topic
    {
        //[Column("ID")]
        public int Id { get; set; }

        //[MaxLength(50)]
        public string Name { get; set; }
        
    }
}
