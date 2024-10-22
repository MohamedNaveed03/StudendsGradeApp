using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudendsGradeApp.Migrations
{
    /// <inheritdoc />
    public partial class StudentValid9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Students",
                type: "TEXT",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Students");
        }
    }
}
