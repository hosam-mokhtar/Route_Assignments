using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    //[Table("Stud_Course")]
    internal class StudentCourse
    {
        //[Column("stud_ID")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        //[Column("Course_ID")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public int Grade { get; set; }

    }
}
