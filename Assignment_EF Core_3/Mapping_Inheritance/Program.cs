using Mapping_Inheritance.Data;
using Mapping_Inheritance.Data.Models;

namespace Mapping_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MyCompanyContext myCompanyContext = new MyCompanyContext();

            #region Add Data in DB (TPCT - TPH - TPT)

            var emp01 = new FullTimeEmployee()
            {
                Name = "Radwa",
                Address = "11 - Cairo",
                Age = 25,
                Salary = 50_002,
                StartDate = DateTime.Now
            };

            var emp02 = new PartTimeEmployee()
            {
                Name = "Nada",
                Address = "12 - Giza",
                Age = 25,
                HourRate = 400,
                CountOfHrs = 100
            };

            //myCompanyContext.FullTimeEmployees.Add(emp01);
            //myCompanyContext.PartTimeEmployees.Add(emp02);

            //myCompanyContext.SaveChanges();

            #endregion

            #region Retrive Data from DB (TPCT)

            //var fullTimeEmployees = myCompanyContext.FullTimeEmployees.FirstOrDefault();
            //var partTimeEmployees = myCompanyContext.PartTimeEmployees.FirstOrDefault();


            //if (fullTimeEmployees is not null)
            //    Console.WriteLine(fullTimeEmployees.Name);
            //Console.WriteLine("------------------------------------------------------------");
            //if (partTimeEmployees is not null)
            //    Console.WriteLine(partTimeEmployees.Name);

            #endregion

            #region Retrive Data from DB (TPH) - (TPT)

            //var fullTimeEmployees = myCompanyContext.FullTimeEmployees.ToList();


            //if (fullTimeEmployees is not null)
            //{
            //    foreach (var item in fullTimeEmployees)
            //        Console.WriteLine($"{item.Name} ,, {item.Salary}");
            //}

            #endregion

            #region Retrive Data from DB (TPH) without (Dbsets (FullTimeEmployees, PartTimeEmployees))

            //var res = myCompanyContext.Employees.ToList();

            //if (res is not null)
            //{
            //    foreach (var item in res.OfType<FullTimeEmployee>())
            //        Console.WriteLine($"{item.Name} ,, {item.Salary}");
            //}

            #endregion

        }
    }
}
