using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class emailkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Client",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Client_Email",
                table: "Client",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Client_Email",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Client",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
