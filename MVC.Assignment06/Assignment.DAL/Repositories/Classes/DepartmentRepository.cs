using Assignment.DAL.Models.DepartmentModel;
using Assignment.DAL.Repositories.Interfaces;

namespace Assignment.DAL.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext _context) 
               : GenericRepository<Department>(_context), IDepartmentRepository
    {

    }
}
