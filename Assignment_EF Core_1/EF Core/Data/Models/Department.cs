using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    internal class Department
    {
        //[Column("ID")]
        public int Id { get; set; }

        //[MaxLength(50)]
        //I need to print ErrorMessage in Front-End 
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public DateTime HiringDate { get; set; }

        //[Column("Ins_ID")]
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

    }
}
