using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
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

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MessageResultDto>> GetAllMessagesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<MessageResultDto> GetAsync(long Id)
    {
        throw new NotImplementedException();
    }
}
