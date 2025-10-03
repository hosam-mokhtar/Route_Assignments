using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    internal class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }

        #region (M - M) (Student - Course) Relationship
        //Must Create DbSet<StudentCourse>
        public Student Student { get; set; }
        public Course Course { get; set; }

        #endregion

    }
}
