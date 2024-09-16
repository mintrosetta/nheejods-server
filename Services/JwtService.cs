using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using nheejods.Models;
using nheejods.Services.Interfaces;

namespace nheejods.Services;

public class JwtService : IJwtService
{
    private readonly string key;
    private readonly string issuer;
    private readonly string audience;

    public JwtService(IConfiguration configuration)
    {
        string? keyTemp = configuration.GetSection("Jwt:Key").Get<string>();
        string? issuerTemp = configuration.GetSection("Jwt:Issuer").Get<string>();
        string? audienceTemp = configuration.GetSection("Jwt:Audience").Get<string>();

        if (keyTemp == null || issuerTemp == null || audienceTemp == null) throw new Exception("Data initialize for generate token not found");

        this.key = keyTemp;
        this.issuer = issuerTemp;
        this.audience = audienceTemp;
    }

    public string GenerateToken(User user)
    {
        try 
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] keyBytes = Encoding.UTF8.GetBytes(this.key);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Issuer = this.issuer,
                Audience = this.audience,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
        catch (Exception ex) 
        {
            throw new Exception(ex.Message);
        }
    }
}
