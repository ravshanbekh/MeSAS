using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http; 
public class JwtService
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly IHttpContextAccessor _httpContextAccessor; 

    public JwtService(string secretKey, string issuer, string audience, IHttpContextAccessor httpContextAccessor)
    {
        _secretKey = secretKey;
        _issuer = issuer;
        _audience = audience;
        _httpContextAccessor = httpContextAccessor; 
    }

    public long GetUserIdFromToken()
    {
        var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        return Convert.ToInt64(userIdClaim.Value);
    }

    public string GenerateToken()
    {
        var userId = GetUserIdFromToken(); 

        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _issuer,
            _audience,
            new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            },
            expires: DateTime.Now.AddHours(1), 
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
