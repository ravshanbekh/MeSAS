using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Analyses;
using Service.DTOs.Bookings;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services;

public class AnalyseService : IAnalyseService
{
    private readonly IMapper mapper;
    private readonly IRepository<Analyse> repository;

    public AnalyseService(IRepository<Analyse> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<AnalyseResultDto> CreateAsync(AnalyseCreationDto dto)
    {
        var mappedAnalyse = mapper.Map<Analyse>(dto);
        await this.repository.AddAsync(mappedAnalyse);
        await this.repository.SaveAsync();

        var result = mapper.Map<AnalyseResultDto>(mappedAnalyse);
        return result;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        Analyse existAnalyse = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existAnalyse is null)
        {
            throw new NotFoundException($"This Analyse is not found with Id-{id}");
        }

        this.repository.Remove(existAnalyse);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<AnalyseResultDto>> GetAllAnalysesAsync()
    {
        var Analyses = await this.repository.SelectAll().ToListAsync();
        var result = mapper.Map<IEnumerable<AnalyseResultDto>>(Analyses);
        return result;
    }

    public async Task<AnalyseResultDto> GetAsync(long id)
    {
        Analyse existAnalyse = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existAnalyse is null)
        {
            throw new NotFoundException($"This Analyse is not found with Id-{id}");
        }
        return mapper.Map<AnalyseResultDto>(existAnalyse);
    }
}
