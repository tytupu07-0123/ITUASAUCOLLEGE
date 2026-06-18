using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITU_ASAU_COLLEGE.Migrations
{
    /// <inheritdoc />
    public partial class TeacherUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Teacher_TeacherId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_TeacherId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_TeacherId",
                table: "Student",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherId",
                table: "Student",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId");
        }
    }
}
