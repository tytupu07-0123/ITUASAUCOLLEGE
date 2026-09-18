using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITU_ASAU_COLLEGE.Migrations
{
    /// <inheritdoc />
    public partial class Addcourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_EnrollmentApplications_EnrollmentApplicationId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_EnrollmentApplicationId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "EnrollmentApplicationId",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "Courses",
                table: "EnrollmentApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Courses",
                table: "EnrollmentApplications");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentApplicationId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_EnrollmentApplicationId",
                table: "Course",
                column: "EnrollmentApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_EnrollmentApplications_EnrollmentApplicationId",
                table: "Course",
                column: "EnrollmentApplicationId",
                principalTable: "EnrollmentApplications",
                principalColumn: "EnrollmentApplicationId");
        }
    }
}
