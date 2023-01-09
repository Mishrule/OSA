using Microsoft.EntityFrameworkCore.Migrations;

namespace OSA.Infrastructure.Migrations
{
    public partial class AddedFullNameToGuardian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Guardians",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Guardians");
        }
    }
}
