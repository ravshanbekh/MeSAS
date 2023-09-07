using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Messages;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services;

public class MessageService : IMessageService
{
    private readonly IMapper mapper;
    private readonly IRepository<Message> repository;

    public MessageService(IRepository<Message> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<MessageResultDto> CreateAsync(MessageCreationDto dto)
    { 
        var mappedMessage = mapper.Map<Message>(dto);
        await this.repository.AddAsync(mappedMessage);
        await this.repository.SaveAsync();

        var result = mapper.Map<MessageResultDto>(mappedMessage);
        return result;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        Message existMessage = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existMessage is null)
        {
            throw new NotFoundException($"This Message is not found with Id-{id}");
        }

        this.repository.Remove(existMessage);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<MessageResultDto>> GetAllMessagesAsync()
    {
        var Messages = await this.repository.SelectAll().ToListAsync();
        var result = mapper.Map<IEnumerable<MessageResultDto>>(Messages);
        return result;
    }

    public async Task<MessageResultDto> GetAsync(long id)
    {
        Message existMessage = await this.repository.SelectAsync(x => x.Id.Equals(id));

        if (existMessage is null)
        {
            throw new NotFoundException($"This Message is not found with Id-{id}");
        }
        return mapper.Map<MessageResultDto>(existMessage);
    }
}
