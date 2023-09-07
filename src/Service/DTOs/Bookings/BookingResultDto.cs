using Service.DTOs.Doctors;
using Service.DTOs.Users;

namespace Service.DTOs.Bookings;

public class BookingResultDto
{
    public long Id { get; set; }
    public UserResultDto User { get; set; }
    public DoctorResultDto Doctor { get; set; }
    public DateTime MeetingDate { get; set; }
}
