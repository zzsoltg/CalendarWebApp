using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupLeaderToGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupLeaderId",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 12, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 12, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupLeaderId",
                table: "Groups",
                column: "GroupLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_GroupLeaderId",
                table: "Groups",
                column: "GroupLeaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_GroupLeaderId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupLeaderId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupLeaderId",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
