using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    FK_Customer = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_FK_Customer",
                        column: x => x.FK_Customer,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("a2730fa7-d7e0-40f0-bb5f-75092d8c5583"),
                column: "Name",
                value: "Magazin Generale");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FK_Customer",
                table: "Comments",
                column: "FK_Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("a2730fa7-d7e0-40f0-bb5f-75092d8c5583"),
                column: "Name",
                value: "Magazain Generale");
        }
    }
}
