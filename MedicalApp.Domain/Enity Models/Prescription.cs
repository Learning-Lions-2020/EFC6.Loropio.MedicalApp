namespace MedicalApp.Domain
{
    public class Prescription
    {
        public int Id { get; set; }
        public string? Medication { get; set; }
        public string? Dosage { get; set; }

        //Foreign Keys

        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
