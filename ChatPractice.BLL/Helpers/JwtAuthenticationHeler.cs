using Ardalis.Result;
using ChatPractice.DAL.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChatPractice.BLL.Helpers;
public class JwtAuthenticationHeler
{
    private readonly IConfiguration _configuration;
    public JwtAuthenticationHeler(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(string userId, string email)
    {
        var TokenHandler = new JwtSecurityTokenHandler();
        var key = _configuration["Jwt:Key"]!;

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email.ToString())
        };


        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpirationTimeMinutes"]!)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:Issuer"],
        };

        var token = TokenHandler.CreateToken(tokenDescriptor);
        return TokenHandler.WriteToken(token);
    }
}
