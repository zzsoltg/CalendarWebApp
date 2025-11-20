using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalendarWebApp.Migrations
{
    /// <inheritdoc />
    public partial class NewAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start", "Text", "Type" },
                values: new object[] { new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), "Szabi", "Szabadság" });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start", "Text", "Type" },
                values: new object[] { new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "HO", "HomeOffice" });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start", "Text", "Type" },
                values: new object[] { new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "AI tanfolyam", "Képzés" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Appointment");

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start", "Text" },
                values: new object[] { new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "Birthday" });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start", "Text" },
                values: new object[] { new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "Day off" });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start", "Text" },
                values: new object[] { new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "Work from home" });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "End", "Start", "Text" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 11, 13, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 13, 10, 0, 0, 0, DateTimeKind.Local), "Online meeting" },
                    { 5, new DateTime(2025, 11, 13, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 13, 10, 0, 0, 0, DateTimeKind.Local), "Skype call" },
                    { 6, new DateTime(2025, 11, 13, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 13, 14, 0, 0, 0, DateTimeKind.Local), "Dentist appointment" },
                    { 7, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), "Vacation" }
                });
        }
    }
}
