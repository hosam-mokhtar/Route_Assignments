using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    //[Table("Course_Inst")]
    internal class CourseInstructor
    {
        //[Column("inst_ID")]
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        //[Column("Course_ID")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        //[MaxLength(200)]
        public string Evaluate { get; set; }
    }
}
