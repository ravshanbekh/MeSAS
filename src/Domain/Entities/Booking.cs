using Domain.Commons;

namespace Domain.Entities;

public class Booking : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long DoctorId { get; set;}
    public Doctor Doctor { get; set; }
    public DateTime MeetingDate { get; set; }
}
