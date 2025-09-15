using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;

namespace EF_Core.Data.Models
{
    internal class Student
    {
        //[Column("ID")]
        public int Id { get; set; }

        //[Column("FName")]
        //[MaxLength(30)]
        public string FirstName { get; set; }

        //[Column("LName")]
        //[MaxLength(30)]
        public string LastName { get; set; }

        //[MaxLength(150)]
        public string? Address { get; set; }
        public int Age { get; set; }
        
        //[Column("Dep_Id")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

    }
}
