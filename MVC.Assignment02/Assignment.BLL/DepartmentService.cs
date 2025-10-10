using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DAL.Data.Contexts;

namespace Assignment.BLL
{
    public class DepartmentService
    {

        public DepartmentService()
        {
            //ApplicationDbContext context = new ApplicationDbContext(); // XXXX
        }

        public void UpdateDepartment(int id /*,departmentviewmodel*/)
        {
            //Get Department From Database By Given Id
            //Call Repository.GetById(id , context)        //No Logic 

        }
    }
}
