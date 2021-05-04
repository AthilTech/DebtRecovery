using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Scenarios_FK_Scenario",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Scenarios_FK_Scenario",
                table: "Customers",
                column: "FK_Scenario",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Scenarios_FK_Scenario",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Scenarios_FK_Scenario",
                table: "Customers",
                column: "FK_Scenario",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
