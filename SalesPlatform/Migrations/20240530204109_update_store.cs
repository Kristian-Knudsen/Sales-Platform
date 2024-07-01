using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesPlatform.Migrations
{
    /// <inheritdoc />
    public partial class update_store : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_Storeid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_OwnerId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Products_Storeid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Storeid",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Stores",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_OwnerId",
                table: "Stores",
                newName: "IX_Stores_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_id",
                table: "Products",
                column: "id",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Users_UserId",
                table: "Stores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_UserId",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Stores",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_UserId",
                table: "Stores",
                newName: "IX_Stores_OwnerId");

            migrationBuilder.AddColumn<Guid>(
                name: "Storeid",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_Storeid",
                table: "Products",
                column: "Storeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_Storeid",
                table: "Products",
                column: "Storeid",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Users_OwnerId",
                table: "Stores",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
