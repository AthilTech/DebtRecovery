using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class workplease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PromiseDate",
                table: "Promises");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Promises",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Promises");

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PromiseDate",
                table: "Promises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
