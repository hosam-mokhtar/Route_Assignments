using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DAL.Repositories.Interfaces;

namespace Assignment.DAL.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork  /* , IDisposable*/
    {
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(IEmployeeRepository employeeRepository, 
                          IDepartmentRepository departmentRepository, 
                          ApplicationDbContext dbContext)
        {
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(dbContext));
            _dbContext = dbContext;
        }

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;
        public IEmployeeRepository EmployeeRepository =>  _employeeRepository.Value;

        //public void Dispose()
        //{

        //    //Some Actions



        //    _dbContext.Dispose();
        //}

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
