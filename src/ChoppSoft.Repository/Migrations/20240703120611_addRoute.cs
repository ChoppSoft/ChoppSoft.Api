using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoppSoft.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Complete = table.Column<bool>(type: "boolean", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_RouteId",
                table: "Addresses",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ResourceId",
                table: "Routes",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_RouteId",
                table: "Addresses",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Routes_RouteId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_RouteId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Addresses");
        }
    }
}
