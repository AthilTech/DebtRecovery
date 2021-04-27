using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BillTrips",
                table: "BillTrips");

            migrationBuilder.DropColumn(
                name: "BillTripId",
                table: "BillTrips");

            migrationBuilder.AddColumn<Guid>(
                name: "BillTripId",
                table: "BillTrips",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillTrips",
                table: "BillTrips",
                column: "BillTripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BillTrips",
                table: "BillTrips");

            migrationBuilder.DropColumn(
                name: "BillTripId",
                table: "BillTrips");

            migrationBuilder.AddColumn<Guid>(
                name: "BillTripId",
                table: "BillTrips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillTrips",
                table: "BillTrips",
                column: "BillTripId");
        }
    }
}
