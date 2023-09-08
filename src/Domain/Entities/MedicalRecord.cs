using Domain.Commons;

namespace Domain.Entities;

public class MedicalRecord : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime DiagnosisDate { get; set; }
    public string Diagnosis { get; set; }
    public string Treatment { get; set; }
    public ICollection<Analyse> Analyse { get; set; }
}
