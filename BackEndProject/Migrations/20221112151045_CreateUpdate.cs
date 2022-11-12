using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class CreateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MainImage",
                table: "ShopProducts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "ShopProducts");
        }
    }
}
