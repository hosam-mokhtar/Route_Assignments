using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class _11RelationshipsDepartmentInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Instructor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_ManagerId",
                table: "Instructor",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Department_ManagerId",
                table: "Instructor",
                column: "ManagerId",
                principalTable: "Department",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Department_ManagerId",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_ManagerId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Instructor");
        }
    }
}
