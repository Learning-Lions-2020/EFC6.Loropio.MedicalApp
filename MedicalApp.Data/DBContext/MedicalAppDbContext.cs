using MedicalApp.Domain;
using Microsoft.EntityFrameworkCore;

public class MedicalAppDbContext : DbContext
{
    public MedicalAppDbContext(DbContextOptions<MedicalAppDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = 1, Name = "Brizan Were", DateOfBirth = new DateTime(1993, 5, 1), Address = "123 Kalokol" },
            new Patient { Id = 2, Name = "June Helderly", DateOfBirth = new DateTime(1995, 8, 15), Address = "456 Arizona" },
            new Patient { Id = 3, Name = "Alice Makeke", DateOfBirth = new DateTime(1996, 2, 11), Address = "Bujumbura Tw" },
            new Patient { Id = 4, Name = "Kuya Nacho", DateOfBirth = new DateTime(1992, 3, 30), Address = "Kanamkemer Str" }
        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { Id = 1, Name = "Dr. Thomas", DateOfBirth = new DateTime(1980, 4, 20), Address = "Berlin, Germany" },
            new Doctor { Id = 2, Name = "Dr. Jerry", DateOfBirth = new DateTime(1975, 2, 10), Address = "Nairobi, Kenya" },
            new Doctor { Id = 3, Name = "Dr. Boniface", DateOfBirth = new DateTime(1972, 6, 15), Address = "Kampala, Uganda" },
            new Doctor { Id = 4, Name = "Dr. Olsen", DateOfBirth = new DateTime(1978, 11, 22), Address = "Juba, South Sudan" }
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment { Id = 1, PatientId = 1, DoctorId = 1, Date = new DateTime(2024, 10, 1) },
            new Appointment { Id = 2, PatientId = 2, DoctorId = 2, Date = new DateTime(2024, 10, 2) },
            new Appointment { Id = 3, PatientId = 3, DoctorId = 3, Date = new DateTime(2024, 10, 3) },
            new Appointment { Id = 4, PatientId = 4, DoctorId = 4, Date = new DateTime(2024, 10, 4) }
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { Id = 1, AppointmentId = 1, Medication = "Amoxicillin", Dosage = "500 mg" },
            new Prescription { Id = 2, AppointmentId = 2, Medication = "Ibuprofen", Dosage = "200 mg" },
            new Prescription { Id = 3, AppointmentId = 3, Medication = "Paracetamol", Dosage = "500 mg" },
            new Prescription { Id = 4, AppointmentId = 4, Medication = "Cetirizine", Dosage = "10 mg" }
        );

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId);

        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Appointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Prescription)
            .WithOne(p => p.Appointment)
            .HasForeignKey<Prescription>(p => p.AppointmentId);
    }
}
