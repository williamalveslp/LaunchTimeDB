using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Services.Base;

namespace LaunchTimeDB.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        User GetLogin(string userName, string password);
        bool IsValid(long id, string userName, string name, bool isNew);

        long GetNextId();
    }
}
