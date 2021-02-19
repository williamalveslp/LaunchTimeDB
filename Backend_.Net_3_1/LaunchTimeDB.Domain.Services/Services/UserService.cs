using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
            entity.SetIdFake(GetNextId());

            if (!IsValid(entity.Id, entity.UserName, entity.Name, true))
                return null;

            return _userRepository.Insert(entity);
        }

        public User Update(User entity)
        {
            if (!IsValid(entity.Id, entity.UserName, entity.Name, false))
                return null;

            return _userRepository.Update(entity);
        }

        public IList<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(long entityId)
        {
            return _userRepository.GetById(entityId);
        }

        public void DeleteById(long entityId)
        {
            _userRepository.DeleteById(entityId);
        }

        public User GetLogin(string userName, string password)
        {
            return _userRepository.GetLogin(userName, password);
        }

        public bool IsValid(long id, string userName, string name, bool isNew)
        {
            var allUsers = GetAll();

            string messageErrors = string.Empty;

            User hasSameId = null;
            if (isNew)
                hasSameId = allUsers.Where(f => f.Id == id).FirstOrDefault();

            if (hasSameId != null)
                messageErrors += $"Já existe com este mesmo Id.\r\n";

            User hasSameUserName = null;
            if (isNew)
                hasSameUserName = allUsers.Where(f => f.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
            else
                hasSameUserName = allUsers.Where(f => (f.Id != id) && (f.UserName.ToLower() == userName.ToLower())).FirstOrDefault();

            if (hasSameUserName != null)
                messageErrors += $"Usuário '{userName}' já existe.\r\n";

            User hasSameName = null;

            if (isNew)
                hasSameName = allUsers.Where(f => f.Name.ToLower() == name.ToLower()).FirstOrDefault();
            else
                hasSameName = allUsers.Where(f => (f.Id != id) && (f.Name.ToLower() == name.ToLower())).FirstOrDefault();

            if (hasSameName != null)
                messageErrors += $"Nome de Usuário '{name}' já existe.\r\n";

            if (!string.IsNullOrEmpty(messageErrors))
                throw new Exception(messageErrors);

            return true;
        }

        public long GetNextId()
        {
            var allUsers = _userRepository.GetAll();

            if (allUsers.Count <= 0)
                return 1;

            return allUsers.Max(f => f.Id) + 1;
        }
    }
}
