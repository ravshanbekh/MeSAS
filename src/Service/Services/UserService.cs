using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Service.DTOs.Users;
using Service.Exceptions;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services;

public class UserService : IUserService
{

    private readonly IMapper mapper;
    private readonly IRepository<User> repository;
    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        User existUser = await this.repository.SelectAsync(u => u.Phone.Equals(dto.Phone));
        if (existUser is not null)
            throw new AlreadyExistException($"This user is already exists with phone = {dto.Phone}");

        var mappedUser = this.mapper.Map<User>(dto);
        mappedUser.Password = PasswordHash.Encrypt(mappedUser.Password);
        await this.repository.AddAsync(mappedUser);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(mappedUser);
        return result;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {id}");

        this.repository.Remove(existUser);
        await this.repository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<UserResultDto>> GetAllUsersAsync()
    {
        var users = await this.repository.SelectAll()
           .ToPaginate(@params)
           .ToListAsync();
        var result = this.mapper.Map<IEnumerable<UserResultDto>>(users);
        return result;
    }

    public async Task<UserResultDto> GetAsync(long id)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {id}");

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<UserResultDto> UpdateAsync(UserUpdateDto dto)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {dto.Id}");

        this.mapper.Map(dto, existUser);
        existUser.Password = PasswordHash.Encrypt(dto.Password);
        this.repository.Modify(existUser);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }
}
