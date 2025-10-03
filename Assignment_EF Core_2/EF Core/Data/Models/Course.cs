using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        #region (M - M) (Student - Course) Relationship
        //public List<Student> Students { get; set; }                         //old
        //public List<StudentCourse> StudentsCourses { get; set; }            //new
        #endregion

        #region (M - M) (Instructor - Course) Relationship
        //public List<Instructor> Instructors { get; set; }                   //old
        //public List<StudentCourse> StudentsCourses { get; set; }            //new
        #endregion

        #region (1 - M) (Topic- Course) Relationship
        public int TopicId { get; set; }
        public Topic Topics { get; set; }
        #endregion

    }
}
