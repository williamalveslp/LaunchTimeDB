﻿using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories.Base;

namespace LaunchTimeDB.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetLogin(string userName, string password);
    }
}
