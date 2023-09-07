using Domain.Commons;
using Domain.Entitiesrg;
using Domain.Enums;

namespace Domain.Entities;

public  class Analyse : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public long MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; }
    public AnalyseType AnalyseType { get; set; }
    public string Description { get; set; }
    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}
