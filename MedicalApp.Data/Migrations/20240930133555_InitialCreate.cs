using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, "Berlin, Germany", new DateTime(1980, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Thomas" },
                    { 2, "Nairobi, Kenya", new DateTime(1975, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Jerry" },
                    { 3, "Kampala, Uganda", new DateTime(1972, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Boniface" },
                    { 4, "Juba, South Sudan", new DateTime(1978, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Olsen" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1993, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe" },
                    { 2, "456 Elm St", new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith" },
                    { 3, "789 Pine St", new DateTime(1996, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Makeke" },
                    { 4, "Kanamkemer Str", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuya Nacho" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 30, 16, 35, 55, 634, DateTimeKind.Local).AddTicks(4212), 1, 1 },
                    { 2, new DateTime(2024, 10, 1, 16, 35, 55, 634, DateTimeKind.Local).AddTicks(4224), 2, 2 },
                    { 3, new DateTime(2024, 10, 2, 16, 35, 55, 634, DateTimeKind.Local).AddTicks(4227), 3, 3 },
                    { 4, new DateTime(2024, 10, 3, 16, 35, 55, 634, DateTimeKind.Local).AddTicks(4229), 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "AppointmentId", "Dosage", "Medication" },
                values: new object[,]
                {
                    { 1, 1, "500 mg", "Amoxicillin" },
                    { 2, 2, "200 mg", "Ibuprofen" },
                    { 3, 3, "500 mg", "Paracetamol" },
                    { 4, 4, "10 mg", "Cetirizine" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
