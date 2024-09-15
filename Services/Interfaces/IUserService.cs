using nheejods.Services.Dtos.User;

namespace nheejods.Services.Interfaces;

public interface IUserService
{
    Task CreateAsync(CreateUserDto createUserDto);
    Task<bool> EmailIsExistsAsync(string email);
}
