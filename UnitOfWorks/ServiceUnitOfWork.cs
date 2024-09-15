using nheejods.Services;
using nheejods.Services.Interfaces;
using nheejods.UnitOfWorks.Interfaces;

namespace nheejods.UnitOfWorks;

public class ServiceUnitOfWork : IServiceUnitOfWork
{
    public ServiceUnitOfWork(IRepoUnitOfWork repo)
    {
        this.UserService = new UserService(repo);
    }
    public IUserService UserService { get; private set; }
}
