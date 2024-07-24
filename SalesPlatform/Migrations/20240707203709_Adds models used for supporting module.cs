using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesPlatform.Migrations
{
    /// <inheritdoc />
    public partial class Addsmodelsusedforsupportingmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInteractionChannels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInteractionChannels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInteractionStatusses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInteractionStatusses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInteractions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customerId = table.Column<Guid>(type: "uuid", nullable: false),
                    customerInteractionStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    customerInteractionChannelId = table.Column<Guid>(type: "uuid", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInteractions", x => x.id);
                    table.ForeignKey(
                        name: "FK_CustomerInteractions_CustomerInteractionChannels_customerIn~",
                        column: x => x.customerInteractionChannelId,
                        principalTable: "CustomerInteractionChannels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInteractions_CustomerInteractionStatusses_customerI~",
                        column: x => x.customerInteractionStatusId,
                        principalTable: "CustomerInteractionStatusses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInteractions_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInteractionMessages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    interactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    responderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerInteractionid = table.Column<Guid>(type: "uuid", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInteractionMessages", x => new { x.interactionId, x.id });
                    table.ForeignKey(
                        name: "FK_CustomerInteractionMessages_CustomerInteractions_CustomerIn~",
                        column: x => x.CustomerInteractionid,
                        principalTable: "CustomerInteractions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CustomerInteractionMessages_CustomerInteractions_interactio~",
                        column: x => x.interactionId,
                        principalTable: "CustomerInteractions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInteractionMessages_Users_responderId",
                        column: x => x.responderId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInteractionMessages_CustomerInteractionid",
                table: "CustomerInteractionMessages",
                column: "CustomerInteractionid");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInteractionMessages_responderId",
                table: "CustomerInteractionMessages",
                column: "responderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInteractions_customerId",
                table: "CustomerInteractions",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInteractions_customerInteractionChannelId",
                table: "CustomerInteractions",
                column: "customerInteractionChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInteractions_customerInteractionStatusId",
                table: "CustomerInteractions",
                column: "customerInteractionStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInteractionMessages");

            migrationBuilder.DropTable(
                name: "CustomerInteractions");

            migrationBuilder.DropTable(
                name: "CustomerInteractionChannels");

            migrationBuilder.DropTable(
                name: "CustomerInteractionStatusses");
        }
    }
}
