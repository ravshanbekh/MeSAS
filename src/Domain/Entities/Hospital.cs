using Domain.Commons;
using Domain.Enums;

namespace Domain.Entities;

public class Hospital : Auditable
{
    public string HospitalName { get; set; }
    public string Location { get; set; }
    public HospitalType HospitalType { get; set; }
    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Message> Messages { get; set; }
}
