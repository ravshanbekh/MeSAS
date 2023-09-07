using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Bookings;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services;

public class BookingService : IBookingService
{
    private readonly IMapper mapper;
    private readonly IRepository<Booking> repository;

    public BookingService(IRepository<Booking> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<BookingResultDto> CreateAsync(BookingCreationDto dto)
    {
        var mappedBooking = mapper.Map<Booking>(dto);
        await this.repository.AddAsync(mappedBooking);
        await this.repository.SaveAsync();

        var result = mapper.Map<BookingResultDto>(mappedBooking);
        return result;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        Booking existBooking = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existBooking is null)
        {
            throw new NotFoundException($"This Booking is not found with Id-{id}");
        }

        this.repository.Remove(existBooking);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<BookingResultDto>> GetAllBookingsAsync()
    {
        var Bookings = await this.repository.SelectAll().ToListAsync();
        var result = mapper.Map<IEnumerable<BookingResultDto>>(Bookings);
        return result;
    }

    public async Task<BookingResultDto> GetAsync(long id)
    {
        Booking existBooking = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existBooking is null)
        {
            throw new NotFoundException($"This Booking is not found with Id-{id}");
        }
        return mapper.Map<BookingResultDto>(existBooking);
    }

    public async Task<BookingResultDto> UpdateAsync(BookingUpdateDto dto)
    {
        Booking existBooking = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
        if (existBooking is null)
            throw new NotFoundException($"This Booking is not found with ID = {dto.Id}");

        this.mapper.Map(dto, existBooking);
        this.repository.Modify(existBooking);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<BookingResultDto>(existBooking);
        return result;
    }
}
