using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill_Trips",
                table: "Bill_Trips");

            migrationBuilder.DropColumn(
                name: "TripBillId",
                table: "Bill_Trips");

            migrationBuilder.AddColumn<Guid>(
                name: "Bill_TripId",
                table: "Bill_Trips",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill_Trips",
                table: "Bill_Trips",
                column: "Bill_TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill_Trips",
                table: "Bill_Trips");

            migrationBuilder.DropColumn(
                name: "Bill_TripId",
                table: "Bill_Trips");

            migrationBuilder.AddColumn<Guid>(
                name: "TripBillId",
                table: "Bill_Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill_Trips",
                table: "Bill_Trips",
                column: "TripBillId");
        }
    }
}
