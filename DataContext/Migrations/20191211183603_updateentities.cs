using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicationDataContext.Migrations
{
    public partial class updateentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Editing",
                table: "TodoList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Editing",
                table: "TodoList",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
