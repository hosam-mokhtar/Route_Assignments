using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping_Inheritance.Data.Models
{
    public class PartTimeEmployee : Employee
    {
        public decimal HourRate { get; set; }
        public int CountOfHrs { get; set; }
    }
}
