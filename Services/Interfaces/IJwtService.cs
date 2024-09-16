using nheejods.Models;

namespace nheejods.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
