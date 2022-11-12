using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class CreateModelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopProductModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ShopProductId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProductModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopProductModels_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductModels_ShopProduct_ShopProductId",
                        column: x => x.ShopProductId,
                        principalTable: "ShopProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductModels_ModelId",
                table: "ShopProductModels",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductModels_ShopProductId",
                table: "ShopProductModels",
                column: "ShopProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopProductModels");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
