public class AppointmentDto
{
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public int PrescriptionId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Medication { get; set; }
    public string Dosage { get; set; }
}



