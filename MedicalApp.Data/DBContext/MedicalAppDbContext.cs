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

        // Data Seeding
        modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1993, 5, 1), Address = "123 Main St" },
            new Patient { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1995, 8, 15), Address = "456 Elm St" },
            new Patient { Id = 3, Name = "Alice Makeke", DateOfBirth = new DateTime(1995, 8, 15), Address = "789 Pine St" },
            new Patient { Id = 4, Name = "Kuya Nacho", DateOfBirth = new DateTime(1995, 8, 15), Address = "Kanamkemer str" }



        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { Id = 1, Name = "Dr Thomas", DateOfBirth = new DateTime(1980, 4, 20), Address = "Berlin, Germany" },
            new Doctor { Id = 2, Name = "Dr Jerry", DateOfBirth = new DateTime(1975, 2, 10), Address = "Nairobi, Kenya" },
            new Doctor { Id = 3, Name = "Dr Boniface", DateOfBirth = new DateTime(1975, 2, 10), Address = "Kampala, Uganda" },
            new Doctor { Id = 4, Name = "Dr Olsen", DateOfBirth = new DateTime(1975, 2, 10), Address = "Juba, South Sudan" }

        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment { Id = 1, PatientId = 1, DoctorId = 1, Date = DateTime.Now },
            new Appointment { Id = 2, PatientId = 2, DoctorId = 2, Date = DateTime.Now.AddDays(1) }
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { Id = 1, AppointmentId = 1, Medication = "Medication A", Dosage = "10mg" },
            new Prescription { Id = 2, AppointmentId = 2, Medication = "Medication B", Dosage = "20mg" }
        );

        // Configure Relationships
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
