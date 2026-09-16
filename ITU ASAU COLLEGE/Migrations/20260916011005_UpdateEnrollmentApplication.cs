using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITU_ASAU_COLLEGE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnrollmentApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Courses",
                table: "EnrollmentApplications");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "EnrollmentApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentApplications_CourseId",
                table: "EnrollmentApplications",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentApplications_Course_CourseId",
                table: "EnrollmentApplications",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentApplications_Course_CourseId",
                table: "EnrollmentApplications");

            migrationBuilder.DropIndex(
                name: "IX_EnrollmentApplications_CourseId",
                table: "EnrollmentApplications");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "EnrollmentApplications");

            migrationBuilder.AddColumn<string>(
                name: "Courses",
                table: "EnrollmentApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
