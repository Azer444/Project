using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class CreateServiceTableAddHeaderColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutService",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Footer",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Services",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Footer",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "AboutService",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
