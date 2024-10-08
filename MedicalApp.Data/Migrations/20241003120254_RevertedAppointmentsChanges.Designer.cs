﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalApp.Data.Migrations
{
    [DbContext(typeof(MedicalAppDbContext))]
    [Migration("20241003120254_RevertedAppointmentsChanges")]
    partial class RevertedAppointmentsChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalApp.Domain.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 1,
                            PatientId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 2,
                            PatientId = 2
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 3,
                            PatientId = 3
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 4,
                            PatientId = 4
                        });
                });

            modelBuilder.Entity("MedicalApp.Domain.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Berlin, Germany",
                            DateOfBirth = new DateTime(1980, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dr. Thomas"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Nairobi, Kenya",
                            DateOfBirth = new DateTime(1975, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dr. Jerry"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Kampala, Uganda",
                            DateOfBirth = new DateTime(1972, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dr. Boniface"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Juba, South Sudan",
                            DateOfBirth = new DateTime(1978, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dr. Olsen"
                        });
                });

            modelBuilder.Entity("MedicalApp.Domain.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Kalokol",
                            DateOfBirth = new DateTime(1993, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brizan Were"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Arizona",
                            DateOfBirth = new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "June Helderly"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Bujumbura Tw",
                            DateOfBirth = new DateTime(1996, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Alice Makeke"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Kanamkemer Str",
                            DateOfBirth = new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kuya Nacho"
                        });
                });

            modelBuilder.Entity("MedicalApp.Domain.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            Dosage = "500 mg",
                            Medication = "Amoxicillin"
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 2,
                            Dosage = "200 mg",
                            Medication = "Ibuprofen"
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 3,
                            Dosage = "500 mg",
                            Medication = "Paracetamol"
                        },
                        new
                        {
                            Id = 4,
                            AppointmentId = 4,
                            Dosage = "10 mg",
                            Medication = "Cetirizine"
                        });
                });

            modelBuilder.Entity("MedicalApp.Domain.Appointment", b =>
                {
                    b.HasOne("MedicalApp.Domain.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalApp.Domain.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalApp.Domain.Prescription", b =>
                {
                    b.HasOne("MedicalApp.Domain.Appointment", "Appointment")
                        .WithOne("Prescription")
                        .HasForeignKey("MedicalApp.Domain.Prescription", "AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("MedicalApp.Domain.Appointment", b =>
                {
                    b.Navigation("Prescription")
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalApp.Domain.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("MedicalApp.Domain.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
