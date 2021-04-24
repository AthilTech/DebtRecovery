using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    ScenarioId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.ScenarioId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CIN = table.Column<string>(nullable: true),
                    FK_Role = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    AgentId = table.Column<Guid>(nullable: true),
                    FK_Manager = table.Column<Guid>(nullable: true),
                    ManagerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_FK_Manager",
                        column: x => x.FK_Manager,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_FK_Role",
                        column: x => x.FK_Role,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Media = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Auto = table.Column<bool>(nullable: false),
                    FK_Scenario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Scenarios_FK_Scenario",
                        column: x => x.FK_Scenario,
                        principalTable: "Scenarios",
                        principalColumn: "ScenarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Tel_m = table.Column<string>(nullable: true),
                    Tel_f = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CIN = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    FK_Agent = table.Column<Guid>(nullable: false),
                    FK_Scenario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Users_FK_Agent",
                        column: x => x.FK_Agent,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Scenarios_FK_Scenario",
                        column: x => x.FK_Scenario,
                        principalTable: "Scenarios",
                        principalColumn: "ScenarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    NbPayments = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Scenario_State = table.Column<bool>(nullable: false),
                    FK_Client = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_Clients_FK_Client",
                        column: x => x.FK_Client,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(nullable: false),
                    Activity = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true),
                    Agent_Name = table.Column<string>(nullable: true),
                    Bill_Num = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_Histories_Bills_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_Bills_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    AmountToPay = table.Column<double>(nullable: false),
                    PayedAmount = table.Column<double>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bills_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promises",
                columns: table => new
                {
                    PromiseId = table.Column<Guid>(nullable: false),
                    PromiseDate = table.Column<DateTime>(nullable: false),
                    AmountPromised = table.Column<double>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promises", x => x.PromiseId);
                    table.ForeignKey(
                        name: "FK_Promises_Bills_FK_Bill",
                        column: x => x.FK_Bill,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FK_Scenario",
                table: "Activities",
                column: "FK_Scenario");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Trips_FK_Bill",
                table: "Bill_Trips",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_FK_Client",
                table: "Bills",
                column: "FK_Client");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FK_Agent",
                table: "Clients",
                column: "FK_Agent");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FK_Scenario",
                table: "Clients",
                column: "FK_Scenario");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_FK_Bill",
                table: "Histories",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_FK_Bill",
                table: "Notes",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FK_Bill",
                table: "Payments",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Promises_FK_Bill",
                table: "Promises",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FK_Manager",
                table: "Users",
                column: "FK_Manager");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FK_Role",
                table: "Users",
                column: "FK_Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Bill_Trips");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Promises");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
