using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class nullableforeignkeysclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_FK_Agent",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Scenarios_FK_Scenario",
                table: "Clients");

            migrationBuilder.AlterColumn<Guid>(
                name: "FK_Scenario",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "FK_Agent",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_FK_Agent",
                table: "Clients",
                column: "FK_Agent",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Scenarios_FK_Scenario",
                table: "Clients",
                column: "FK_Scenario",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_FK_Agent",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Scenarios_FK_Scenario",
                table: "Clients");

            migrationBuilder.AlterColumn<Guid>(
                name: "FK_Scenario",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FK_Agent",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_FK_Agent",
                table: "Clients",
                column: "FK_Agent",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Scenarios_FK_Scenario",
                table: "Clients",
                column: "FK_Scenario",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
