using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class MMRelationshipsStudentCourseInstructorCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stud_Course_Course_ID",
                table: "Stud_Course",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Inst_Course_ID",
                table: "Course_Inst",
                column: "Course_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Inst_Course_Course_ID",
                table: "Course_Inst",
                column: "Course_ID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Inst_Instructor_inst_ID",
                table: "Course_Inst",
                column: "inst_ID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stud_Course_Course_Course_ID",
                table: "Stud_Course",
                column: "Course_ID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stud_Course_Student_stud_ID",
                table: "Stud_Course",
                column: "stud_ID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Inst_Course_Course_ID",
                table: "Course_Inst");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Inst_Instructor_inst_ID",
                table: "Course_Inst");

            migrationBuilder.DropForeignKey(
                name: "FK_Stud_Course_Course_Course_ID",
                table: "Stud_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Stud_Course_Student_stud_ID",
                table: "Stud_Course");

            migrationBuilder.DropIndex(
                name: "IX_Stud_Course_Course_ID",
                table: "Stud_Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_Inst_Course_ID",
                table: "Course_Inst");
        }
    }
}
