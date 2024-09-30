using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Appointments");

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

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Berlin, Germany", "Dr Thomas" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Nairobi, Kenya", "Dr Jerry" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 3, "Kampala, Uganda", new DateTime(1975, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr Boniface" },
                    { 4, "Juba, South Sudan", new DateTime(1975, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr Olsen" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 3, "789 Pine St", new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Makeke" },
                    { 4, "Kanamkemer str", new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuya Nacho" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "MyProperty" },
                values: new object[] { new DateTime(2024, 9, 30, 8, 27, 15, 371, DateTimeKind.Local).AddTicks(8787), 1 });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "MyProperty" },
                values: new object[] { new DateTime(2024, 10, 1, 8, 27, 15, 371, DateTimeKind.Local).AddTicks(8795), 2 });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Name" },
                values: new object[] { "789 Maple St", "Dr. Adams" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Name" },
                values: new object[] { "101 Pine St", "Dr. Baker" });
        }
    }
}
