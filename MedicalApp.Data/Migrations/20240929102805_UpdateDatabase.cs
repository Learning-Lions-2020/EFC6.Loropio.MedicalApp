using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalApp.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, "789 Maple St", new DateTime(1980, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Adams" },
                    { 2, "101 Pine St", new DateTime(1975, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Baker" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1993, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe" },
                    { 2, "456 Elm St", new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "MyProperty", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 29, 13, 28, 4, 753, DateTimeKind.Local).AddTicks(4841), 1, 1, 1 },
                    { 2, new DateTime(2024, 9, 30, 13, 28, 4, 753, DateTimeKind.Local).AddTicks(4850), 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "AppointmentId", "Dosage", "Medication" },
                values: new object[,]
                {
                    { 1, 1, "10mg", "Medication A" },
                    { 2, 2, "20mg", "Medication B" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
