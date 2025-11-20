namespace Assignment.PL.ViewModels.DepartmentViewModels
{
    public class DepartmentViewModel
    {
        //public int Id { get; set; }

        public string Name { get; set; } = string.Empty; // In Case (Name) allow null
        public string Code { get; set; } = string.Empty; // In Case (Code) allow null
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }      // During insertion must add Time to DateTime
    }
}
