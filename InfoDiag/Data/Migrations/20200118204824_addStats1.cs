using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addStats1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NbOccurence",
                table: "StatLine",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbOccurence",
                table: "StatLine");
        }
    }
}
