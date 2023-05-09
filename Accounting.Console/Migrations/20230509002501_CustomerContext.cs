using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting.Console.Migrations
{
    public partial class CustomerContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CustomerContext");

            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "AccountContext",
                newName: "Customer",
                newSchema: "CustomerContext");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "CustomerContext",
                newName: "Customer",
                newSchema: "AccountContext");
        }
    }
}
