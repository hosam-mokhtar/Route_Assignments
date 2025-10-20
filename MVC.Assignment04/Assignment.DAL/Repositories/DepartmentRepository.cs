
namespace Assignment.DAL.Repositories
{
    // Primary Constructor .Net 8 Feature
    public class DepartmentRepository(ApplicationDbContext context) : IDepartmentRepository
    // High Level Model
    {
        //High Level Model don't depend on Low Level Model directly
        //ApplicationDbContext context = new ApplicationDbContext();       // Low Level Model
        private readonly ApplicationDbContext _context = context;

        //public DepartmentRepository(/*Service A*/,ApplicationDbContext context) :this(context)
        //{
        //}

        #region 5 CRUD Operations 

        //1-Get Department By ID
        //public Department? GetById(int id, ApplicationDbContext context)
        //{
        //    //Find() take one KeyValue => id
        //    var department = _context.Departments.Find(id);
        //    return department;
        //}

        // or lambda expression
        public Department? GetById(int id/*, ApplicationDbContext context*/)
                           => _context.Departments.Find(id);

        //2-Get All Departments
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _context.Departments.ToList();
            else
                return _context.Departments.AsNoTracking().ToList();
        }

        //3-Add Department
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }
        //4-Update Department
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        //5-Delete Department
        public int Remove(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }
        #endregion

    }
}
