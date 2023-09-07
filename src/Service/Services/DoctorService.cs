using AutoMapper;
using DAL.IRepositories;
using Domain.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Doctors;
using Service.Exceptions;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services;

public class DoctorService : IDoctorService
{
    private readonly IMapper mapper;
    private readonly IRepository<Doctor> repository;
    public DoctorService(IRepository<Doctor> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<DoctorResultDto> CreateAsync(DoctorCreationDto dto)
    {
        Doctor existDoctor = await this.repository.SelectAsync(u => u.Phone.Equals(dto.Phone));
        if (existDoctor is not null)
            throw new AlreadyExistException($"This Doctor is already exists with phone = {dto.Phone}");

        var mappedDoctor = this.mapper.Map<Doctor>(dto);
        mappedDoctor.Password = PasswordHash.Encrypt(mappedDoctor.Password);
        await this.repository.AddAsync(mappedDoctor);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<DoctorResultDto>(mappedDoctor);
        return result;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        Doctor existDoctor = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (existDoctor is null)
            throw new NotFoundException($"This Doctor is not found with ID = {id}");

        this.repository.Remove(existDoctor);
        await this.repository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<DoctorResultDto>> GetAllDoctorsAsync()
    {
        var Doctors = await this.repository.SelectAll()
           .ToListAsync();
        //.ToPaginate(@params)
        var result = this.mapper.Map<IEnumerable<DoctorResultDto>>(Doctors);
        return result;
    }

    public Task<IEnumerable<DoctorResultDto>> GetAllDoctorsAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<DoctorResultDto> GetAsync(long id)
    {
        Doctor existDoctor = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (existDoctor is null)
            throw new NotFoundException($"This Doctor is not found with ID = {id}");

        var result = this.mapper.Map<DoctorResultDto>(existDoctor);
        return result;
    }

    public async Task<DoctorResultDto> UpdateAsync(DoctorUpdateDto dto)
    {
        Doctor existDoctor = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
        if (existDoctor is null)
            throw new NotFoundException($"This Doctor is not found with ID = {dto.Id}");

        this.mapper.Map(dto, existDoctor);
        existDoctor.Password = PasswordHash.Encrypt(dto.Password);
        this.repository.Modify(existDoctor);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<DoctorResultDto>(existDoctor);
        return result;
    }
}
