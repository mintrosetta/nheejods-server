using nheejods.Services;
using nheejods.Services.Interfaces;
using nheejods.UnitOfWorks.Interfaces;

namespace nheejods.UnitOfWorks;

public class ServiceUnitOfWork : IServiceUnitOfWork
{
    public ServiceUnitOfWork(IRepoUnitOfWork repo, IConfiguration configuration)
    {
        this.UserService = new UserService(repo);
        this.JwtService = new JwtService(configuration);
    }
    public IUserService UserService { get; private set; }
    public IJwtService JwtService { get; private set; }
}
