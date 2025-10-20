using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.BLL.DTOs
{
    public class CreatedDepartmentDto
    {
        [MaxLength(10)]
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Date Of Creation")]
        public DateOnly DateOfCreation { get; set; }      // During insertion must add Time to DateTime
    }
}
