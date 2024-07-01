using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoppSoft.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updateResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOwned",
                table: "Resource",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwned",
                table: "Resource");
        }
    }
}
