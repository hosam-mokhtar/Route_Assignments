
namespace Assignment.DAL.Repositories
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool withTracking = false);

        Department? GetById(int id);
        //Department? GetById(int id, ApplicationDbContext context);

        int Remove(Department department);
        int Update(Department department);
    }
}