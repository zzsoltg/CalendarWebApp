using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingDescriptionToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "End", "Start" },
                values: new object[] { null, new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "End", "Start" },
                values: new object[] { null, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "End", "Start" },
                values: new object[] { null, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Appointment");

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
