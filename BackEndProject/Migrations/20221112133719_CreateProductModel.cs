using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class CreateProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "ShopProduct",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopProduct_ModelId",
                table: "ShopProduct",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProduct_Models_ModelId",
                table: "ShopProduct",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopProduct_Models_ModelId",
                table: "ShopProduct");

            migrationBuilder.DropIndex(
                name: "IX_ShopProduct_ModelId",
                table: "ShopProduct");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "ShopProduct");
        }
    }
}
