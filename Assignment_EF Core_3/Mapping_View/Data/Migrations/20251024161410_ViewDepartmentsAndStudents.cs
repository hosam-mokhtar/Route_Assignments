using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mapping_View.Data.Migrations
{
    /// <inheritdoc />
    public partial class ViewDepartmentsAndStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view DepartmentsAndStudents
                                   with encryption, schemabinding
                                   as
                                   select d.ID, d.Name as 'DepartmentName', concat(s.FName, s.LName) as 'StudentName'
                                   from dbo.Department d left outer join dbo.Student s
                                   on d.ID = s.Dep_Id
                                  ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view DepartmentsAndStudents");
        }
    }
}
