using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class okeh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "NbPayments",
                table: "Bills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AmountToPay",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NbPayments",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
