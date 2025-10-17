using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.BLL.DTOs
{
    public class UpdateDepartmentDto : CreeatedDepartmentDto
    {
        public int Id { get; set; }

        //public string Name { get; set; }
        //public string Code { get; set; }
        //public string? Description { get; set; }
        //public DateOnly DateOfCreation { get; set; }      // During insertion must add Time to DateTime
    }
}
