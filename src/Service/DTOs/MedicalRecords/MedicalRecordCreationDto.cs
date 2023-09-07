namespace Service.DTOs.MedicalRecords;

public class MedicalRecordCreationDto
{
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public DateTime DiagnosisDate { get; set; }
    public string Diagnosis { get; set; }
    public string Treatment { get; set; }
}
