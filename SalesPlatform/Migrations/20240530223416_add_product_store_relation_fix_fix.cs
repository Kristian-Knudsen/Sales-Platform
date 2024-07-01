using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesPlatform.Migrations
{
    /// <inheritdoc />
    public partial class add_product_store_relation_fix_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StoreId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_id",
                table: "Products",
                column: "id",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_id",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
