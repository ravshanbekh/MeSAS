using Domain.Commons;

namespace Domain.Entities;

public class Doctor : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Score { get; set; }
    public string Specialization { get; set; }
    public string LicenseNumber { get; set; }
    public long HospitalId { get; set; }
    public Hospital Hospital { get; set; }
    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
    public ICollection<Booking> Booking { get; set; }
}
