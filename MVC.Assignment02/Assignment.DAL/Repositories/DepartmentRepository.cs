using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DAL.Data.Contexts;

namespace Assignment.DAL.Repositories
{
    // Primary Constructor .Net 8 Feature
    internal class DepartmentRepository(ApplicationDbContext context) // High Level Model
    {
        //High Level Model don't depend on Low Level Model directly
        //ApplicationDbContext context = new ApplicationDbContext();       // Low Level Model
        private readonly ApplicationDbContext _context = context;

        //public DepartmentRepository(/*Service A*/,ApplicationDbContext context) :this(context)
        //{
        //}

        //5 CRUD Operations 
        //1-Get Department By ID
        public Department? GetById(int id, ApplicationDbContext context)
        {
            //Find() take one KeyValue => id
            var department = context.Departments.Find(id);
            return department;
        }
        //2-Get All Departments
        //3-Add Department
        //4-Update Department
        //5-Delete Department



    }
}
