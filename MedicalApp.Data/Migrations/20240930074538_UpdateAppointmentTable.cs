using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 30, 10, 45, 38, 54, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 1, 10, 45, 38, 54, DateTimeKind.Local).AddTicks(1330));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 30, 10, 40, 57, 335, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 1, 10, 40, 57, 335, DateTimeKind.Local).AddTicks(92));
        }
    }
}
