﻿using DAL.IRepositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Exceptions;
using Service.Helpers;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services;

public class AuthService:IAuthService
{
    private readonly IConfiguration configuration;
    private readonly IRepository<User> userRepository;
    public AuthService(IRepository<User> userRepository, IConfiguration configuration)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
    }

    public async Task<string> GenerateTokenAsync(string phone, string originalPassword)
    {
        var user = await this.userRepository.SelectAsync(u => u.Phone.Equals(phone));
        if (user is null)
            throw new NotFoundException("This user is not found");

        bool verifiedPassword = PasswordHash.Verify(user.Password, originalPassword);
        if (!verifiedPassword)
            throw new CustomException(400, "Phone or password is invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
          {
             new Claim("Phone", user.Phone),
             new Claim("Id", user.Id.ToString()),
             new Claim(ClaimTypes.Role, user.Role.ToString())
          }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        string result = tokenHandler.WriteToken(token);
        return result;
    }
}
