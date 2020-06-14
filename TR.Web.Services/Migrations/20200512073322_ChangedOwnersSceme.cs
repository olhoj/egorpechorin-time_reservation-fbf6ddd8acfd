using Microsoft.EntityFrameworkCore.Migrations;

namespace TR.Web.Services.Migrations
{
    public partial class ChangedOwnersSceme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Diapason",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Diapason");
        }
    }
}
