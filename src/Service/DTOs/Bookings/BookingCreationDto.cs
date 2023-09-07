namespace Service.DTOs.Bookings;

public class BookingCreationDto
{
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public DateTime MeetingDate { get; set; }
}
