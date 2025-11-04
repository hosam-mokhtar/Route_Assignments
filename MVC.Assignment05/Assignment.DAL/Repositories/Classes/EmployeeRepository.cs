using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DAL.Repositories.Interfaces;

namespace Assignment.DAL.Repositories.Classes
{
    public class EmployeeRepository(ApplicationDbContext _context) 
                : GenericRepository<Employee>(_context), IEmployeeRepository
    {
        

    }
}
