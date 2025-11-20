using Assignment.DAL.Models.Shared;

namespace Assignment.DAL.Models.DepartmentModel
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;              //Ignore null
        public string Code { get; set; } = null!;              //Ignore null
        public string? Description { get; set; }



        public virtual ICollection<Employee> Employees { get; set; }
        //or
        //public virtual List<Employee> Employees { get; set; }
    }
}
