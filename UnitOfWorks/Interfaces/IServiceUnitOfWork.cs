using nheejods.Services.Interfaces;

namespace nheejods.UnitOfWorks.Interfaces;

public interface IServiceUnitOfWork
{
    public IUserService UserService { get; }
}
