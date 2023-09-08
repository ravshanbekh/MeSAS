using Service.DTOs.Doctors;
using Service.DTOs.Users;

namespace Service.DTOs.Bookings;

public class BookingResultDto
{
    public long Id { get; set; }
    public ICollection <UserResultDto> User { get; set; }
    public ICollection <DoctorResultDto> Doctor { get; set; }
    public DateTime MeetingDate { get; set; }
}
