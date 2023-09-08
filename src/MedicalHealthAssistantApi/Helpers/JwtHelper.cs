using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Text;
using Service.Exceptions;

public static class JwtHelper
{

    public static long GetUserIdFromTokenAsync(string token,IConfiguration configuration)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            if (validatedToken is JwtSecurityToken jwtToken && jwtToken.Subject != null)
            {
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "Id");
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
            }
        }
        catch (Exception)
        {
            // Invalid token
        }

        throw new CustomException(400, "Invalid token");
    }

}
