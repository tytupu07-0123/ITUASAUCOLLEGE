using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITU_ASAU_COLLEGE.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCourseidfromEnrollmentApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentApplications_Course_CourseId",
                table: "EnrollmentApplications");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "EnrollmentApplications",
                newName: "CoursesCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_EnrollmentApplications_CourseId",
                table: "EnrollmentApplications",
                newName: "IX_EnrollmentApplications_CoursesCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentApplications_Course_CoursesCourseId",
                table: "EnrollmentApplications",
                column: "CoursesCourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentApplications_Course_CoursesCourseId",
                table: "EnrollmentApplications");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseId",
                table: "EnrollmentApplications",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_EnrollmentApplications_CoursesCourseId",
                table: "EnrollmentApplications",
                newName: "IX_EnrollmentApplications_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentApplications_Course_CourseId",
                table: "EnrollmentApplications",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
