using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TR.Web.Services.Migrations
{
    public partial class ChangedDiapModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDayTime",
                table: "Diapason");

            migrationBuilder.DropColumn(
                name: "StartDayTime",
                table: "Diapason");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDay",
                table: "Diapason",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishTime",
                table: "Diapason",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDay",
                table: "Diapason",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Diapason",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDay",
                table: "Diapason");

            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "Diapason");

            migrationBuilder.DropColumn(
                name: "StartDay",
                table: "Diapason");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Diapason");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDayTime",
                table: "Diapason",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDayTime",
                table: "Diapason",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
