using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class CreateShopProductAddDetailDescColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ShopProducts",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<string>(
                name: "DetailDesc",
                table: "ShopProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailDesc",
                table: "ShopProducts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ShopProducts",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
