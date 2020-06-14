using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TR.Web.Services.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingVariant",
                columns: table => new
                {
                    MeetingVariantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingVariant", x => x.MeetingVariantID);
                });

            migrationBuilder.CreateTable(
                name: "Diapason",
                columns: table => new
                {
                    DiapasonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingVariantID = table.Column<int>(nullable: false),
                    IsMonday = table.Column<bool>(nullable: false),
                    IsTuesday = table.Column<bool>(nullable: false),
                    IsWednesday = table.Column<bool>(nullable: false),
                    IsThursday = table.Column<bool>(nullable: false),
                    IsFriday = table.Column<bool>(nullable: false),
                    IsSaturday = table.Column<bool>(nullable: false),
                    IsSunday = table.Column<bool>(nullable: false),
                    StartDayTime = table.Column<DateTime>(nullable: false),
                    FinishDayTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diapason", x => x.DiapasonID);
                    table.ForeignKey(
                        name: "FK_Diapason_MeetingVariant_MeetingVariantID",
                        column: x => x.MeetingVariantID,
                        principalTable: "MeetingVariant",
                        principalColumn: "MeetingVariantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    SlotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiapasonID = table.Column<int>(nullable: false),
                    MeetingVariantID = table.Column<int>(nullable: false),
                    StartSlotTime = table.Column<DateTime>(nullable: false),
                    FinishSlotTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<DateTime>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.SlotID);
                    table.ForeignKey(
                        name: "FK_Slot_Diapason_DiapasonID",
                        column: x => x.DiapasonID,
                        principalTable: "Diapason",
                        principalColumn: "DiapasonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_MeetingVariant_MeetingVariantID",
                        column: x => x.MeetingVariantID,
                        principalTable: "MeetingVariant",
                        principalColumn: "MeetingVariantID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedSlot",
                columns: table => new
                {
                    AcceptedSlotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotID = table.Column<int>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    ClientContactMail = table.Column<string>(nullable: true),
                    ClientComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedSlot", x => x.AcceptedSlotID);
                    table.ForeignKey(
                        name: "FK_AcceptedSlot_Slot_SlotID",
                        column: x => x.SlotID,
                        principalTable: "Slot",
                        principalColumn: "SlotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedSlot_SlotID",
                table: "AcceptedSlot",
                column: "SlotID");

            migrationBuilder.CreateIndex(
                name: "IX_Diapason_MeetingVariantID",
                table: "Diapason",
                column: "MeetingVariantID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_DiapasonID",
                table: "Slot",
                column: "DiapasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_MeetingVariantID",
                table: "Slot",
                column: "MeetingVariantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedSlot");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Diapason");

            migrationBuilder.DropTable(
                name: "MeetingVariant");
        }
    }
}
