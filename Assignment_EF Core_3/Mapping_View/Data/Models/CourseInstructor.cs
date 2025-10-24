using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping_View.Data.Models
{
    internal class CourseInstructor
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }

        public string Evaluate { get; set; }

        #region (M - M) (Instructor - Course) Relationship

        //Must Create DbSet<CourseInstructor>
        public Instructor? Instructor { get; set; }
        public Course? Course { get; set; }
        #endregion
    }
}
