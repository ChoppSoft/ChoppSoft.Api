using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChoppSoft.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true
            );

            migrationBuilder.Sql(@$"
                INSERT INTO ""Users"" (""Id"", ""Name"", ""Email"", ""Password"", ""Role"", ""Active"", ""CreatedAt"", ""UpdatedAt"")
                VALUES ('f02a0eef-8250-4ccd-b9d4-a6219bd692bf', 'admin', 'admin@choppsoft.com.br', '$2a$10$mbrJdSJfC9JgG0HY7ji3gOpLT.mP2h3fIbiESad0bNwke4sDMgdBO', 'manager', 'true', 'now', 'now')
                ON CONFLICT (""Email"") DO NOTHING;
            "); ;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""Users"" WHERE ""Email"" = 'admin@choppsoft.com.br';
            ");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users"
            );
        }
    }
}
