using System;
using nheejods.Contexts;
using nheejods.Models;
using nheejods.Repositories.Interfaces;

namespace nheejods.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(MySQLDbContext dbContext) : base(dbContext)
    {
    }
}
