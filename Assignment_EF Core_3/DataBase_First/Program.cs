using DataBase_First.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataBase_First
{
    internal class Program
    {
        public class JoinType
        {
            public string EmpName { get; set; }
            public string DeptName { get; set; }
        }
        static void Main(string[] args)
        {
            using ITIDbContext context = new ITIDbContext();

            #region First Way Object from ITIDbContext

            //var res = context.Procedures.SP_GetStudentDataByStudentAddressAsync("Cairo").Result;
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.St_Id} ,, {item.St_Fname}");
            //}

            #endregion


            #region Second Way Object from IITIDbContextProcedures or ITIDbContextProcedures

            //Reference by Interface  
            //IITIDbContextProcedures contextProcedures = new ITIDbContextProcedures(context);
            //or
            //Reference by Class 
            //ITIDbContextProcedures contextProcedures = new ITIDbContextProcedures(context);

            //var res = contextProcedures.SP_GetStudentDataByStudentAddressAsync("Cairo").Result;
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.St_Id} ,, {item.St_Fname}");
            //} 
            #endregion


            #region  Run Sql Query

            #region To Execute (Select or DQL) Statement :: FromSqlRaw() , FromSqlInterpolated()

            //var res = context.Employees.FromSqlRaw("select top (5) * from Employees");

            //int num = 5;

            //String Composition (FromSqlRaw())
            //var res = context.Employees.FromSqlRaw("select top ({0}) * from Employees", num);

            //String Interpolation (FromSqlInterpolated())
            //var res = context.Employees.FromSqlInterpolated($"select top ({num}) * from Employees");

            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.Fname} {item.Lname} : {item.Salary}");
            //}


            // Join

            //var joinResult = context.Database.SqlQuery<JoinType>($"select e.Fname, d.Dept_Name from employees e, Department d where e.Dno = d.Dept_Id");

            //foreach (var item in joinResult)
            //{
            //    Console.WriteLine($"{item.EmpName} {item.DeptName}");
            //}

            #endregion


            #region To Execute DML Statement  :: ExecuteSqlRaw() , ExecuteSqlInterpolated()

            //var catId = 10;

            //String Composition (ExecuteSqlRaw())
            //context.Database.ExecuteSqlRaw("update Department set Dept_Name = 'New' where Dept_Id = {0}", catId);


            //String Interpolation (ExecuteSqlInterpolated())
            //context.Database.ExecuteSqlInterpolated($"update Department set Dept_Name = 'SD' where Dept_Id = {catId}");

            #endregion

            #endregion
        }
    }
}
