using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace LaunchTimeDB.Domain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User Insert(User entity)
        {
            return _userRepository.Insert(entity);
        }

        public User Update(User entity)
        {
            return _userRepository.Update(entity);
        }

        public IList<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int entityId)
        {
            return _userRepository.GetById(entityId);
        }

        public void DeleteById(int entityId)
        {
            _userRepository.DeleteById(entityId);
        }
    }
}
