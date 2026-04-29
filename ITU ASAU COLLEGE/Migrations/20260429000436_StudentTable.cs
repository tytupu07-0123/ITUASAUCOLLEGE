using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITU_ASAU_COLLEGE.Migrations
{
    /// <inheritdoc />
    public partial class StudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassCode",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassCode",
                table: "Teacher");
        }
    }
}
