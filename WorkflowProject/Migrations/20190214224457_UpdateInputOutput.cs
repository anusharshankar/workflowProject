using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowProject.Migrations
{
    public partial class UpdateInputOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Action_Process_ProcessId",
                table: "Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedure_Policy_PolicyId",
                table: "Procedure");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_Procedure_ProcedureId",
                table: "Process");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedureId",
                table: "Process",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Procedure",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutputDesc",
                table: "Output",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InputDesc",
                table: "Input",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Action",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Process_ProcessId",
                table: "Action",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedure_Policy_PolicyId",
                table: "Procedure",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "PolicyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Procedure_ProcedureId",
                table: "Process",
                column: "ProcedureId",
                principalTable: "Procedure",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Action_Process_ProcessId",
                table: "Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedure_Policy_PolicyId",
                table: "Procedure");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_Procedure_ProcedureId",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "OutputDesc",
                table: "Output");

            migrationBuilder.DropColumn(
                name: "InputDesc",
                table: "Input");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedureId",
                table: "Process",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Procedure",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Action",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Process_ProcessId",
                table: "Action",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedure_Policy_PolicyId",
                table: "Procedure",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "PolicyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Procedure_ProcedureId",
                table: "Process",
                column: "ProcedureId",
                principalTable: "Procedure",
                principalColumn: "ProcedureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
