using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddErrorCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErrorCategoryId",
                table: "ErrorCode",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ErrorCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorCode_ErrorCategoryId",
                table: "ErrorCode",
                column: "ErrorCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorCode_ErrorCategory_ErrorCategoryId",
                table: "ErrorCode",
                column: "ErrorCategoryId",
                principalTable: "ErrorCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErrorCode_ErrorCategory_ErrorCategoryId",
                table: "ErrorCode");

            migrationBuilder.DropTable(
                name: "ErrorCategory");

            migrationBuilder.DropIndex(
                name: "IX_ErrorCode_ErrorCategoryId",
                table: "ErrorCode");

            migrationBuilder.DropColumn(
                name: "ErrorCategoryId",
                table: "ErrorCode");
        }
    }
}
