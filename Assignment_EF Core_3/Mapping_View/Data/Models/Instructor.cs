using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mapping_View.Data.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HourRate { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public decimal Bouns { get; set; }

        #region (M - M) (Instructor - Course) Relationship
        //public List<Course> Courses { get; set; }                           //old
        //public List<StudentCourse> StudentsCourses { get; set; }            //new
        #endregion

        #region (1 - M) (Department - Instructor) Relationship
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        #endregion

        #region (1 - 1) (Department - Instructor) Relationship
        public Department DepartmentToManage { get; set; }
        #endregion

    }
}
