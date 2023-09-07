using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Hospitals;
using Service.DTOs.Messages;
using Service.DTOs.Users;
using Service.Exceptions;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services;

public class HospitalService : IHospitalService
{
    private readonly IMapper mapper;
    private readonly IRepository<Hospital> repository;

    public HospitalService(IRepository<Hospital> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<HospitalResultDto> CreateAsync(HospitalCreationDto dto)
    {
        var mappedHospital = mapper.Map<Hospital>(dto);
        await this.repository.AddAsync(mappedHospital);
        await this.repository.SaveAsync();

        var result = mapper.Map<HospitalResultDto>(mappedHospital);
        return result;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        Hospital existHospital = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existHospital is null)
        {
            throw new NotFoundException($"This Hospital is not found with Id-{id}");
        }

        this.repository.Remove(existHospital);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<HospitalResultDto>> GetAllHospitalsAsync()
    {
        var Hospitals = await this.repository.SelectAll().ToListAsync();
        var result = mapper.Map<IEnumerable<HospitalResultDto>>(Hospitals);
        return result;
    }

    public async Task<HospitalResultDto> GetAsync(long id)
    {
        Hospital existHospital = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existHospital is null)
        {
            throw new NotFoundException($"This Hospital is not found with Id-{id}");
        }
        return mapper.Map<HospitalResultDto>(existHospital);
    }
    public async Task<HospitalResultDto> UpdateAsync(HospitalUpdateDto dto)
    {
        Hospital existHospital = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
        if (existHospital is null)
            throw new NotFoundException($"This Hospital is not found with ID = {dto.Id}");

        this.mapper.Map(dto, existHospital);
        this.repository.Modify(existHospital);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<HospitalResultDto>(existHospital);
        return result;
    }
}
