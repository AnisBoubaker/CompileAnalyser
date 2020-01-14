using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CodingLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "CourseGroup");

            migrationBuilder.AddColumn<int>(
                name: "CodingLanguageId",
                table: "ErrorCode",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodingLanguageId",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CodingLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodingLanguage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorCode_CodingLanguageId",
                table: "ErrorCode",
                column: "CodingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CodingLanguageId",
                table: "Course",
                column: "CodingLanguageId");

            migrationBuilder.AddForeignKey(
                            name: "FK_ErrorCode_CodingLanguage_CodingLanguageId",
                            table: "ErrorCode",
                            column: "CodingLanguageId",
                            principalTable: "CodingLanguage",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CodingLanguage_CodingLanguageId",
                table: "Course",
                column: "CodingLanguageId",
                principalTable: "CodingLanguage",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CodingLanguage_CodingLanguageId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorCode_CodingLanguage_CodingLanguageId",
                table: "ErrorCode");

            migrationBuilder.DropTable(
                name: "CodingLanguage");

            migrationBuilder.DropIndex(
                name: "IX_ErrorCode_CodingLanguageId",
                table: "ErrorCode");

            migrationBuilder.DropIndex(
                name: "IX_Course_CodingLanguageId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CodingLanguageId",
                table: "ErrorCode");

            migrationBuilder.DropColumn(
                name: "CodingLanguageId",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "CourseGroup",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
