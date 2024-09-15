using Microsoft.EntityFrameworkCore;
using nheejods.Models;
using nheejods.Services.Dtos.User;
using nheejods.Services.Interfaces;
using nheejods.UnitOfWorks.Interfaces;

namespace nheejods.Services;

public class UserService : IUserService
{
    private readonly IRepoUnitOfWork repo;

    public UserService(IRepoUnitOfWork repo)
    {
        this.repo = repo;
    }

    public async Task CreateAsync(CreateUserDto dto)
    {
        DateTime currentDate = DateTime.Now;
        User user = new User()
        {
            Email = dto.Email,
            Password = dto.PasswordHashed,
            CreatedAt = currentDate,
            UpdatedAt = currentDate
        };

        await this.repo.UserRepository.AddAsync(user);
        await this.repo.CompleteAsync();
    }

    public async Task<bool> EmailIsExistsAsync(string email)
    {
        User? user = await this.repo.UserRepository.Find(user => user.Email.Equals(email)).FirstOrDefaultAsync();

        return (user != null);
    }
}
