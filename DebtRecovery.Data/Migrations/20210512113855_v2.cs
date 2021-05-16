using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtRecovery.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityInstances",
                columns: table => new
                {
                    ActivityInstanceId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    IsAuto = table.Column<bool>(nullable: false),
                    Fk_ScenarioActivity = table.Column<Guid>(nullable: false),
                    FK_bill = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInstances", x => x.ActivityInstanceId);
                    table.ForeignKey(
                        name: "FK_ActivityInstances_Activities_Fk_ScenarioActivity",
                        column: x => x.Fk_ScenarioActivity,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInstances_Fk_ScenarioActivity",
                table: "ActivityInstances",
                column: "Fk_ScenarioActivity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityInstances");
        }
    }
}
