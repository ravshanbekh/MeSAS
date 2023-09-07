using Service.DTOs.Bookings;
using Service.DTOs.Users;

namespace Service.Interfaces;

public interface IBookingService
{
    Task<BookingResultDto> CreateAsync(BookingCreationDto dto);
    Task<BookingResultDto> UpdateAsync(BookingUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<BookingResultDto>> GetAllBookingsAsync();
    Task<BookingResultDto> GetAsync(long Id);
}
