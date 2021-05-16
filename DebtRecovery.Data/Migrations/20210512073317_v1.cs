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
                    ScenarioLabel = table.Column<string>(nullable: true),
                    IsCentralized = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
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
                    Icn = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FK_Subsidiary = table.Column<Guid>(nullable: true),
                    FK_Role = table.Column<Guid>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FK_Manager = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_FK_Manager",
                        column: x => x.FK_Manager,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Users_Roles_FK_Role",
                        column: x => x.FK_Role,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(nullable: false),
                    ActivityLabel = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Media = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsAuto = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    BeforeDays = table.Column<int>(nullable: false),
                    AfterDays = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
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
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    LegalIdentifier = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Litigation = table.Column<bool>(nullable: false),
                    FK_Agent = table.Column<Guid>(nullable: true),
                    FK_Scenario = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Users_FK_Agent",
                        column: x => x.FK_Agent,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Scenarios_FK_Scenario",
                        column: x => x.FK_Scenario,
                        principalTable: "Scenarios",
                        principalColumn: "ScenarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Scenario_State = table.Column<bool>(nullable: false),
                    FK_Customer = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_Customers_FK_Customer",
                        column: x => x.FK_Customer,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillTrips",
                columns: table => new
                {
                    BillTripId = table.Column<Guid>(nullable: false),
                    FK_Trip = table.Column<Guid>(nullable: false),
                    FK_Bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTrips", x => x.BillTripId);
                    table.ForeignKey(
                        name: "FK_BillTrips_Bills_FK_Bill",
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
                    ActionLabel = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ScenarioActivity = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    AgentId = table.Column<string>(nullable: true),
                    AgentName = table.Column<string>(nullable: true),
                    BillNumber = table.Column<string>(nullable: true),
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
                    NoteSubject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Label" },
                values: new object[,]
                {
                    { new Guid("4d2bc0d0-f738-4ba5-b48b-c2db92b0bcf1"), "Admin" },
                    { new Guid("45e6a625-ba74-437b-8956-5316915202ac"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Scenarios",
                columns: new[] { "ScenarioId", "IsActive", "IsCentralized", "ScenarioLabel" },
                values: new object[] { new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"), true, true, "Standard avec une seule Rélance" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Adress", "Discriminator", "Email", "FK_Role", "FK_Subsidiary", "Icn", "LastName", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("14fa108f-986c-44ca-968c-92de280a4f05"), null, "Manager", "Athil Belhadj/SIEGE/POULINA", null, null, null, "Belhadj", "Athil", "23040785" },
                    { new Guid("8becb2c9-1f49-4780-9382-c5d434be11fb"), null, "Manager", "Achref Souissi/SIEGE/POULINA", null, null, null, "Souissi", "Achref", "92365587" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityLabel", "AfterDays", "BeforeDays", "FK_Scenario", "IsAuto", "Media", "Model", "Order", "Type", "date", "isActive" },
                values: new object[,]
                {
                    { new Guid("e0f36a4f-7044-46e7-90b1-923d0737544e"), "Prévenance", 0, 5, new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"), true, "email", "model 1", 0, "thoughtfulness", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("4f4d26bf-e2cf-4d52-8f2b-182b6dc71638"), "Rélance n°1", 3, 0, new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"), true, "email", "model 2", 1, "relaunch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("264e6890-90d2-423e-b795-607499e31a3f"), "Rémerciement", 5, 0, new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"), true, "email", "model 3", 2, "thanks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Adress", "Discriminator", "Email", "FK_Role", "FK_Subsidiary", "Icn", "LastName", "Name", "PhoneNumber", "FK_Manager" },
                values: new object[,]
                {
                    { new Guid("fb2b536c-b4cb-485e-b65f-30679cf0410b"), null, "Agent", "Rami Toumi/SIEGE/POULINA", null, null, null, "Toumi", "Rami", "33256698", new Guid("8becb2c9-1f49-4780-9382-c5d434be11fb") },
                    { new Guid("4b437faf-71a2-47d3-ac14-4088f6a37204"), null, "Agent", "Safouane Ben Jeddi/SIEGE/POULINA", null, null, null, "Ben jeddi", "Safouane", "982544567", new Guid("8becb2c9-1f49-4780-9382-c5d434be11fb") }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Contact", "Email", "FK_Agent", "FK_Scenario", "FaxNumber", "LegalIdentifier", "Litigation", "Name", "PhoneNumber", "Profile" },
                values: new object[] { new Guid("a2730fa7-d7e0-40f0-bb5f-75092d8c5583"), null, "Sfaxi Arij", "Mg@tunis.com.tn", new Guid("fb2b536c-b4cb-485e-b65f-30679cf0410b"), new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"), "70861236", "MLK025F001", false, "Magazain Generale", "71256587", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Contact", "Email", "FK_Agent", "FK_Scenario", "FaxNumber", "LegalIdentifier", "Litigation", "Name", "PhoneNumber", "Profile" },
                values: new object[] { new Guid("17f50cf3-3baa-490e-8716-06c4921f9afe"), null, "Ouni Ramzi", "thabet25@gmail.com", new Guid("fb2b536c-b4cb-485e-b65f-30679cf0410b"), new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"), "70256354", "RCK023MJ556", false, "PV Mazraa sidi Thabet", "23256587", null });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FK_Scenario",
                table: "Activities",
                column: "FK_Scenario");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_FK_Customer",
                table: "Bills",
                column: "FK_Customer");

            migrationBuilder.CreateIndex(
                name: "IX_BillTrips_FK_Bill",
                table: "BillTrips",
                column: "FK_Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FK_Agent",
                table: "Customers",
                column: "FK_Agent");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FK_Scenario",
                table: "Customers",
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
                name: "BillTrips");

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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
