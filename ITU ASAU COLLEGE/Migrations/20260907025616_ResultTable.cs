using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITU_ASAU_COLLEGE.Migrations
{
    /// <inheritdoc />
    public partial class ResultTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_ResultId",
                table: "Student",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Result_ResultId",
                table: "Student",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "ResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Result_ResultId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ResultId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Student");
        }
    }
}
