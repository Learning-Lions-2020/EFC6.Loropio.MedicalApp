using MedicalApp.Domain.Enity_Models.DTOs;

public class AppointmentDto
{
    public DateTime Date { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public PrescriptionDto Prescription { get; set; }  
}


