using Mapping_View.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Mapping_View
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using ItiDbContext context = new ItiDbContext();

            #region Create View

            var data = context.DepartmentsAndStudents.AsNoTracking().ToList();

            if (!data.Any())
            {
                Console.WriteLine("No data found.");
                return;
            }

            foreach (var item in data)
            {
                Console.WriteLine($"{item.DepartmentName} ,, {item.StudentName}");
            }

            #endregion
        }
    }
}
