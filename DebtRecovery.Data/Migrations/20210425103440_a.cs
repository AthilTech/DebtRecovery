using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desciption",
                table: "Scenarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Scenarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desciption",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Scenarios");
        }
    }
}
