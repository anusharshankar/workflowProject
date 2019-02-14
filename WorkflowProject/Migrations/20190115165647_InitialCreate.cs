using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Input",
                columns: table => new
                {
                    InputId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InputTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Input", x => x.InputId);
                });

            migrationBuilder.CreateTable(
                name: "Output",
                columns: table => new
                {
                    OutputId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OutputTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Output", x => x.OutputId);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovalAuthority = table.Column<string>(nullable: true),
                    AdvisoryCommittee = table.Column<string>(nullable: true),
                    Administrator = table.Column<string>(nullable: true),
                    NxtReviewDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    PolicyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PTitle = table.Column<string>(nullable: true),
                    PDescription = table.Column<string>(nullable: true),
                    PScope = table.Column<string>(nullable: true),
                    ReviewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_Policy_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Amendment",
                columns: table => new
                {
                    AmendmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrigApprAuth = table.Column<string>(nullable: true),
                    ApprDate = table.Column<DateTime>(nullable: false),
                    AmendAuth = table.Column<string>(nullable: true),
                    AmendDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PolicyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amendment", x => x.AmendmentId);
                    table.ForeignKey(
                        name: "FK_Amendment_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedure",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrTitle = table.Column<string>(nullable: true),
                    PrDesc = table.Column<string>(nullable: true),
                    PrPurpose = table.Column<string>(nullable: true),
                    PolicyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure", x => x.ProcedureId);
                    table.ForeignKey(
                        name: "FK_Procedure_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    ProcessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcTitle = table.Column<string>(nullable: true),
                    ProcDesc = table.Column<string>(nullable: true),
                    ProcedureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.ProcessId);
                    table.ForeignKey(
                        name: "FK_Process_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedure",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ATitle = table.Column<string>(nullable: true),
                    ADesc = table.Column<string>(nullable: true),
                    InputsInputId = table.Column<int>(nullable: true),
                    OutputsOutputId = table.Column<int>(nullable: true),
                    Departments = table.Column<string>(nullable: true),
                    IsSRSAffected = table.Column<bool>(nullable: false),
                    ProcessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Action_Input_InputsInputId",
                        column: x => x.InputsInputId,
                        principalTable: "Input",
                        principalColumn: "InputId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Action_Output_OutputsOutputId",
                        column: x => x.OutputsOutputId,
                        principalTable: "Output",
                        principalColumn: "OutputId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Action_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Process",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_InputsInputId",
                table: "Action",
                column: "InputsInputId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_OutputsOutputId",
                table: "Action",
                column: "OutputsOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_ProcessId",
                table: "Action",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Amendment_PolicyId",
                table: "Amendment",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_ReviewId",
                table: "Policy",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedure_PolicyId",
                table: "Procedure",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_ProcedureId",
                table: "Process",
                column: "ProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Amendment");

            migrationBuilder.DropTable(
                name: "Input");

            migrationBuilder.DropTable(
                name: "Output");

            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "Procedure");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
