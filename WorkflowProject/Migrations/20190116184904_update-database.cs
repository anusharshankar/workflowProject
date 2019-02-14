using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowProject.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    IncidentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    FiledBy = table.Column<string>(nullable: true),
                    FiledOn = table.Column<DateTime>(nullable: false),
                    Issues = table.Column<string>(nullable: true),
                    StepsTaken = table.Column<string>(nullable: true),
                    ExpectedOutcome = table.Column<string>(nullable: true),
                    ActualOutcome = table.Column<string>(nullable: true),
                    RootCause = table.Column<string>(nullable: true),
                    ChangedExpectation = table.Column<string>(nullable: true),
                    NecessaryFix = table.Column<string>(nullable: true),
                    FixStatus = table.Column<string>(nullable: true),
                    FilerFeedback = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.IncidentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");
        }
    }
}
