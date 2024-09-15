using nheejods.Repositories.Interfaces;

namespace nheejods.UnitOfWorks.Interfaces;

public interface IRepoUnitOfWork
{
    public IUserRepository UserRepository { get; }
    Task CompleteAsync();
}
