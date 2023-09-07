using Domain.Commons;
using Domain.Enums;
using System.Net.Mail;
using System.Security.AccessControl;

namespace Domain.Entities;

public class Hospital : Auditable
{
    public string Name { get; set; }
    public string Location { get; set; }
    public long? AttachmentId { get; set; }
    public HospitalType HospitalType { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Message> Messages { get; set; }
}
