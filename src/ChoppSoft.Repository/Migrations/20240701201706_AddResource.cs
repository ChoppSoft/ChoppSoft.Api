using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoppSoft.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Model = table.Column<string>(type: "varchar(100)", nullable: false),
                    LicensePlate = table.Column<string>(type: "varchar(10)", nullable: false),
                    Capacity = table.Column<double>(type: "numeric(10,4)", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
