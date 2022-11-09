using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class CreateheaderAndDescCoulmnAddShopProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "ShopProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "ShopProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "ShopProducts");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "ShopProducts");
        }
    }
}
