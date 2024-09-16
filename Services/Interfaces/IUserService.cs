using nheejods.Models;
using nheejods.Services.Dtos.User;

namespace nheejods.Services.Interfaces;

public interface IUserService
{
    Task CreateAsync(CreateUserDto createUserDto);
    Task<bool> EmailIsExistsAsync(string email);
    Task<User?> FindByEmailAsync(string email);
    Task<string?> GetPasswordByUserEmailAsync(string email);
}
