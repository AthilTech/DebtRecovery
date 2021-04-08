using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class BillTripUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill_Trips",
                columns: table => new
                {
                    TripBillId = table.Column<Guid>(nullable: false),
                    FK_Trip = table.Column<Guid>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill_Trips", x => x.TripBillId);
                    table.ForeignKey(
                        name: "FK_Bill_Trips_Bills_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Trips_FK_Bill",
                table: "Bill_Trips",
                column: "FK_Bill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill_Trips");
        }
    }
}
