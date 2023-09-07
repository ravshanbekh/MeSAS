using Domain.Commons;
using System.Net.Mail;

namespace Domain.Entities;

public class Doctor : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Score { get; set; }
    public string Specialization { get; set; } // Shifokorning mutaxassisligi
    public string LicenseNumber { get; set; }
    public long HospitalId { get; set; }
    public Hospital Hospital { get; set; }
    public ICollection<Booking> Bookings { get; set; }
}
