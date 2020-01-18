using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    CompilationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Compilation_CompilationId",
                        column: x => x.CompilationId,
                        principalTable: "Compilation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatLine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatsId = table.Column<int>(nullable: false),
                    IsErrorCode = table.Column<bool>(nullable: false),
                    ErrorCodeId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatLine_ErrorCode_ErrorCodeId",
                        column: x => x.ErrorCodeId,
                        principalTable: "ErrorCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatLine_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatLine_ErrorCodeId",
                table: "StatLine",
                column: "ErrorCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatLine_StatsId",
                table: "StatLine",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_CompilationId",
                table: "Stats",
                column: "CompilationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatLine");

            migrationBuilder.DropTable(
                name: "Stats");
        }
    }
}
