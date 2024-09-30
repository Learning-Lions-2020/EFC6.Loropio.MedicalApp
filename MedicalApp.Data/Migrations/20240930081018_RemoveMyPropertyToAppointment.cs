using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMyPropertyToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 30, 11, 10, 18, 116, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 1, 11, 10, 18, 116, DateTimeKind.Local).AddTicks(9421));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
