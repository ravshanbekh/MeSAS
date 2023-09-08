using Domain.Commons;
using Domain.Enums;
using System.Net.Mail;


namespace Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public long? AttachmentId { get; set; }
    public UserRole Role { get; set; }
    public Attachment Attachment { get; set; }
    public ICollection<Message> Message { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<MedicalRecord> MedicalRecords { get; set; }
    public ICollection<Analyse> Analyses { get; set; }
}
