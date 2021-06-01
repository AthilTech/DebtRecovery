using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class userupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubsidiaryCode",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SubsidiaryCode",
                table: "Users");
        }
    }
}
