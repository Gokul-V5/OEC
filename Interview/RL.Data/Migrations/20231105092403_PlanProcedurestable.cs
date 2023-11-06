using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RL.Data.Migrations
{
    public partial class PlanProcedurestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanProcedures",
                table: "PlanProcedures");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PlanProcedures",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanProcedures",
                table: "PlanProcedures",
                columns: new[] { "PlanId", "ProcedureId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanProcedures",
                table: "PlanProcedures");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PlanProcedures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanProcedures",
                table: "PlanProcedures",
                columns: new[] { "PlanId", "ProcedureId" });
        }
    }
}
