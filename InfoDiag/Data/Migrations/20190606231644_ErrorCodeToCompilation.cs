using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ErrorCodeToCompilation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "CompilationError",
                newName: "ErrorCodeId");

            migrationBuilder.AlterColumn<string>(
                name: "ErrorCodeId",
                table: "CompilationError",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompilationError_ErrorCodeId",
                table: "CompilationError",
                column: "ErrorCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompilationError_ErrorCode_ErrorCodeId",
                table: "CompilationError",
                column: "ErrorCodeId",
                principalTable: "ErrorCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompilationError_ErrorCode_ErrorCodeId",
                table: "CompilationError");

            migrationBuilder.DropIndex(
                name: "IX_CompilationError_ErrorCodeId",
                table: "CompilationError");

            migrationBuilder.RenameColumn(
                name: "ErrorCodeId",
                table: "CompilationError",
                newName: "Code");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CompilationError",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
