using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalendarWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "End", "Start", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "Birthday" },
                    { 2, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "Day off" },
                    { 3, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "Work from home" },
                    { 4, new DateTime(2025, 11, 13, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 13, 10, 0, 0, 0, DateTimeKind.Local), "Online meeting" },
                    { 5, new DateTime(2025, 11, 13, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 13, 10, 0, 0, 0, DateTimeKind.Local), "Skype call" },
                    { 6, new DateTime(2025, 11, 13, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 13, 14, 0, 0, 0, DateTimeKind.Local), "Dentist appointment" },
                    { 7, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), "Vacation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
