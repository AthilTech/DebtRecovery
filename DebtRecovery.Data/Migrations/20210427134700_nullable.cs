using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Scenarios_FK_Scenario",
                table: "Customers");

            migrationBuilder.AlterColumn<Guid>(
                name: "FK_Scenario",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "FK_Scenario",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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
