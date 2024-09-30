namespace MedicalApp.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //Foreign Keys
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        // Navigation property for Prescription
        public Prescription? Prescription { get; set; }

    }
}
