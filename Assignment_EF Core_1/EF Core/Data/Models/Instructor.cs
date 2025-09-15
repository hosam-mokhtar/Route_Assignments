using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    internal class Instructor
    {
        //[Column("ID")]
        public int Id { get; set; }

        //[MaxLength(30)]
        public string Name { get; set; }
        
        public int HourRate { get; set; }

        //[MaxLength(150)]
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public decimal Bouns { get; set; }

        //[Column("Dept_ID")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

    }
}
