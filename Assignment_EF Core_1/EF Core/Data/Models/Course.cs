using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace EF_Core.Data.Models
{
    internal class Course
    {
        /*
        //ByConvention (Id or ClassName + Id ) is PK
        //[Key]
        //ByConvention Identity (1 , 1)
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        */
        //[Column("ID")]
        public int Id { get; set; }
        /*
        //By Convention is Required
        //[Required]
        */
        //[MaxLength(30)]
        public string Name { get; set; }
        public int Duration { get; set; }

        //[MaxLength(300)]
        public string Description { get; set; }

        [ForeignKey("Topic")]
        //[Column("Top_ID")]
        public int TopicId { get; set; }
    }
}
