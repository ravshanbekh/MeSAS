using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.MedicalRecords;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IMapper mapper;
    private readonly IRepository<MedicalRecord> repository;

    public MedicalRecordService(IRepository<MedicalRecord> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<MedicalRecordResultDto> CreateAsync(MedicalRecordCreationDto dto)
    {
        var mappedMedicalRecord = mapper.Map<MedicalRecord>(dto);
        await this.repository.AddAsync(mappedMedicalRecord);
        await this.repository.SaveAsync();

        var result = mapper.Map<MedicalRecordResultDto>(mappedMedicalRecord);
        return result;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        MedicalRecord existMedicalRecord = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existMedicalRecord is null)
        {
            throw new NotFoundException($"This MedicalRecord is not found with Id-{id}");
        }

        this.repository.Remove(existMedicalRecord);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<MedicalRecordResultDto>> GetAllMedicalRecordsAsync()
    {
        var MedicalRecords = await this.repository.SelectAll().ToListAsync();
        var result = mapper.Map<IEnumerable<MedicalRecordResultDto>>(MedicalRecords);
        return result;
    }

    public async Task<MedicalRecordResultDto> GetAsync(long id)
    {
        MedicalRecord existMedicalRecord = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existMedicalRecord is null)
        {
            throw new NotFoundException($"This MedicalRecord is not found with Id-{id}");
        }
        return mapper.Map<MedicalRecordResultDto>(existMedicalRecord);
    }
}
