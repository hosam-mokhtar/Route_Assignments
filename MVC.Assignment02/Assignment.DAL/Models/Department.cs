namespace Assignment.DAL.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;              //Ignore null
        public string Code { get; set; } = null!;              //Ignore null
        public string? Description { get; set; }
    } 
}
