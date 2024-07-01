using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesPlatform.Migrations
{
    /// <inheritdoc />
    public partial class many_models_fix_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stores_storeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_storeId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_storeId_isOwner",
                table: "Users",
                columns: new[] { "storeId", "isOwner" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stores_storeId",
                table: "Users",
                column: "storeId",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stores_storeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_storeId_isOwner",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_storeId",
                table: "Users",
                column: "storeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stores_storeId",
                table: "Users",
                column: "storeId",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
