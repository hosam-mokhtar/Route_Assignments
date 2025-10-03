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
        public int Id { get; set; }

        //I need to print ErrorMessage in Front-End 
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public DateTime HiringDate { get; set; }


        #region (1 - M) (Department - Student) Relationship
        public List<Student> Students { get; set; }
        #endregion

        #region (1 - M) (Department - Instructor) Relationship
        public List<Instructor> Instructors { get; set; }
        #endregion

        #region (1 - 1) (Department - Instructor) Relationship
        public int ManagerId { get; set; }
        public Instructor Manager { get; set; }
        #endregion

    }
}
