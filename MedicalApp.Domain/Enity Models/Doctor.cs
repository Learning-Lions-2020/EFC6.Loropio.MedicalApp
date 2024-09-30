namespace MedicalApp.Domain
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
