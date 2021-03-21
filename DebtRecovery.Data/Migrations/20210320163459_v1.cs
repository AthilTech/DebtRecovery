using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    ScenarioId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => x.ScenarioId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Telephonenumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Identitycard = table.Column<int>(nullable: false),
                    Subsidiary_Code = table.Column<int>(nullable: false),
                    FK_Role = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FK_Manager = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_User_FK_Manager",
                        column: x => x.FK_Manager,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role_FK_Role",
                        column: x => x.FK_Role,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Media = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Automatic_send = table.Column<int>(nullable: false),
                    FK_Scenario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activity_Scenario_FK_Scenario",
                        column: x => x.FK_Scenario,
                        principalTable: "Scenario",
                        principalColumn: "ScenarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Profil = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Telephonenumber = table.Column<int>(nullable: false),
                    Telephonenumberfixe = table.Column<int>(nullable: false),
                    FK_Agent = table.Column<Guid>(nullable: false),
                    FK_Scenario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_User_FK_Agent",
                        column: x => x.FK_Agent,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Scenario_FK_Scenario",
                        column: x => x.FK_Scenario,
                        principalTable: "Scenario",
                        principalColumn: "ScenarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<Guid>(nullable: false),
                    Num = table.Column<int>(nullable: false),
                    Totalamount = table.Column<float>(nullable: false),
                    Datecreation = table.Column<DateTime>(nullable: false),
                    Datedeadline = table.Column<DateTime>(nullable: false),
                    Numberpayments = table.Column<int>(nullable: false),
                    ModePayment = table.Column<string>(nullable: true),
                    scenario_state = table.Column<int>(nullable: false),
                    FK_Client = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bill_Client_FK_Client",
                        column: x => x.FK_Client,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bill_Trip",
                columns: table => new
                {
                    Bill_TripId = table.Column<Guid>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill_Trip", x => x.Bill_TripId);
                    table.ForeignKey(
                        name: "FK_bill_Trip_Bill_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_History_Bill_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Note_Bill_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(nullable: false),
                    PaymentMode = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Payrollamount = table.Column<float>(nullable: false),
                    Amountpaid = table.Column<float>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Bill_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promise",
                columns: table => new
                {
                    PromissId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promise", x => x.PromissId);
                    table.ForeignKey(
                        name: "FK_Promise_Bill_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_FK_Scenario",
                table: "Activity",
                column: "FK_Scenario");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_FK_Client",
                table: "Bill",
                column: "FK_Client");

            migrationBuilder.CreateIndex(
                name: "IX_bill_Trip_FK_Bill",
                table: "bill_Trip",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Client_FK_Agent",
                table: "Client",
                column: "FK_Agent");

            migrationBuilder.CreateIndex(
                name: "IX_Client_FK_Scenario",
                table: "Client",
                column: "FK_Scenario");

            migrationBuilder.CreateIndex(
                name: "IX_History_FK_Bill",
                table: "History",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Note_FK_Bill",
                table: "Note",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_FK_Bill",
                table: "Payment",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Promise_FK_Bill",
                table: "Promise",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_User_FK_Manager",
                table: "User",
                column: "FK_Manager");

            migrationBuilder.CreateIndex(
                name: "IX_User_FK_Role",
                table: "User",
                column: "FK_Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "bill_Trip");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Promise");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Scenario");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
