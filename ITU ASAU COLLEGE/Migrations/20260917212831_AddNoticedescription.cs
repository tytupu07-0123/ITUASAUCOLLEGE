using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITU_ASAU_COLLEGE.Migrations
{
    /// <inheritdoc />
    public partial class AddNoticedescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentApplications_Course_CoursesCourseId",
                table: "EnrollmentApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notice_Teacher_TeacherId",
                table: "Notice");

            migrationBuilder.DropIndex(
                name: "IX_EnrollmentApplications_CoursesCourseId",
                table: "EnrollmentApplications");

            migrationBuilder.DropColumn(
                name: "CoursesCourseId",
                table: "EnrollmentApplications");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Notice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoticesTitle",
                table: "Notice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoticeDescription",
                table: "Notice",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notice_Teacher_TeacherId",
                table: "Notice",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_EnrollmentApplications_EnrollmentApplicationId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Notice_Teacher_TeacherId",
                table: "Notice");

            migrationBuilder.DropIndex(
                name: "IX_Course_EnrollmentApplicationId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "EnrollmentApplicationId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Notice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NoticesTitle",
                table: "Notice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoticeDescription",
                table: "Notice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoursesCourseId",
                table: "EnrollmentApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentApplications_CoursesCourseId",
                table: "EnrollmentApplications",
                column: "CoursesCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentApplications_Course_CoursesCourseId",
                table: "EnrollmentApplications",
                column: "CoursesCourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notice_Teacher_TeacherId",
                table: "Notice",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId");
        }
    }
}
