namespace Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.UniqueConstraint("AK_Client_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "ErrorCode",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    TermType = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    ManagerId = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Email", x => x.Email);
                    table.ForeignKey(
                        name: "FK_User_User_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Compilation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    CompilationTime = table.Column<DateTime>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compilation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compilation_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompilationError",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompilationId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    ErrorCodeId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompilationError", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompilationError_Compilation_CompilationId",
                        column: x => x.CompilationId,
                        principalTable: "Compilation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompilationError_ErrorCode_ErrorCodeId",
                        column: x => x.ErrorCodeId,
                        principalTable: "ErrorCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<string>(nullable: true),
                    TermId = table.Column<string>(nullable: true),
                    GroupNumber = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseGroup_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseGroup_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseGroup_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompilationErrorLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    CompilationErrorId = table.Column<long>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompilationErrorLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompilationErrorLine_CompilationError_CompilationErrorId",
                        column: x => x.CompilationErrorId,
                        principalTable: "CompilationError",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseGroupClient",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false),
                    CourseGroupId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroupClient", x => new { x.ClientId, x.CourseGroupId });
                    table.ForeignKey(
                        name: "FK_CourseGroupClient_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseGroupClient_CourseGroup_CourseGroupId",
                        column: x => x.CourseGroupId,
                        principalTable: "CourseGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compilation_ClientId",
                table: "Compilation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CompilationError_CompilationId",
                table: "CompilationError",
                column: "CompilationId");

            migrationBuilder.CreateIndex(
                name: "IX_CompilationError_ErrorCodeId",
                table: "CompilationError",
                column: "ErrorCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompilationErrorLine_CompilationErrorId",
                table: "CompilationErrorLine",
                column: "CompilationErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstitutionId",
                table: "Course",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_CourseId",
                table: "CourseGroup",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_TermId",
                table: "CourseGroup",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_UserId",
                table: "CourseGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroupClient_CourseGroupId",
                table: "CourseGroupClient",
                column: "CourseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ManagerId",
                table: "User",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompilationErrorLine");

            migrationBuilder.DropTable(
                name: "CourseGroupClient");

            migrationBuilder.DropTable(
                name: "CompilationError");

            migrationBuilder.DropTable(
                name: "CourseGroup");

            migrationBuilder.DropTable(
                name: "Compilation");

            migrationBuilder.DropTable(
                name: "ErrorCode");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Institution");
        }
    }
}
