using Service.DTOs.Bookings;
using Service.Interfaces;

namespace Service.Services;

public class BookingService : IBookingService
{
    public Task<BookingResultDto> CreateAsync(BookingCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookingResultDto>> GetAllBookingsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BookingResultDto> GetAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<BookingResultDto> UpdateAsync(BookingUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
