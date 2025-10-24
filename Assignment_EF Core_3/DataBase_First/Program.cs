using DataBase_First.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataBase_First
{
    internal class Program
    {
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
        }
    }
}
