namespace Service.DTOs.Bookings;

public class BookingUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public DateTime MeetingDate { get; set; }
}
