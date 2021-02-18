using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace LaunchTimeDB.DataStore.FakeData
{
    public class UserRepository : IUserRepository
    {
        public User Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
