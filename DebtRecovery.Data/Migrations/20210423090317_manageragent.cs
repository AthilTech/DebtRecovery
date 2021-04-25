using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class manageragent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "litige",
                table: "Clients",
                newName: "Litige");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "Litige",
                table: "Clients",
                newName: "litige");

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Login",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
