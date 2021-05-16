using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionDuration",
                table: "ActivityInstances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "ActivityInstances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentName",
                table: "ActivityInstances",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ActivityInstances",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "ActivityInstances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaType",
                table: "ActivityInstances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanedDate",
                table: "ActivityInstances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScenarioActivityName",
                table: "ActivityInstances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInstances_FK_bill",
                table: "ActivityInstances",
                column: "FK_bill");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInstances_Bills_FK_bill",
                table: "ActivityInstances",
                column: "FK_bill",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInstances_Bills_FK_bill",
                table: "ActivityInstances");

            migrationBuilder.DropIndex(
                name: "IX_ActivityInstances_FK_bill",
                table: "ActivityInstances");

            migrationBuilder.DropColumn(
                name: "ActionDuration",
                table: "ActivityInstances");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "ActivityInstances");

            migrationBuilder.DropColumn(
                name: "AgentName",
                table: "ActivityInstances");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ActivityInstances");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "ActivityInstances");

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "ActivityInstances");

            migrationBuilder.DropColumn(
                name: "PlanedDate",
                table: "ActivityInstances");

            migrationBuilder.DropColumn(
                name: "ScenarioActivityName",
                table: "ActivityInstances");
        }
    }
}
