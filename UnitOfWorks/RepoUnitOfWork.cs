using nheejods.Contexts;
using nheejods.Repositories;
using nheejods.Repositories.Interfaces;
using nheejods.UnitOfWorks.Interfaces;

namespace nheejods.UnitOfWorks;

public class RepoUnitOfWork : IRepoUnitOfWork
{
    private readonly MySQLDbContext dbContext;

    public RepoUnitOfWork(MySQLDbContext dbContext)
    {
        this.UserRepository = new UserRepository(dbContext);
        this.dbContext = dbContext;
    }
    public IUserRepository UserRepository { get; private set; }

    public async Task CompleteAsync()
    {
        await this.dbContext.SaveChangesAsync();
    }
}
