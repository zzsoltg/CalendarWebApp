using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start", "UserId" },
                values: new object[] { new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start", "UserId" },
                values: new object[] { new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start", "UserId" },
                values: new object[] { new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appointment");

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
