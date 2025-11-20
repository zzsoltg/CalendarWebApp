using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingNullableTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
