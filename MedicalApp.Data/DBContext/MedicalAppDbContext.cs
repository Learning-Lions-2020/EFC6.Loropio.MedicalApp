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
        // One-to-Many: Patient -> Appointments
        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId);

        // One-to-Many: Doctor -> Appointments
        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Appointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId);

        // One-to-One: Appointment -> Prescription
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Prescription)
            .WithOne(p => p.Appointment)
            .HasForeignKey<Prescription>(p => p.AppointmentId);
    }
}

