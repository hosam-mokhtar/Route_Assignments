using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping_View.Data.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }

        #region (M - M) (Student - Course) Relationship
        //public List<Course> Courses { get; set; }                   //old
        //public List<StudentCourse> StudentsCourses { get; set; }    //new
        #endregion


        #region (1 - M) (Department - Student) Relationship
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        #endregion


    }
}
