using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Users;
using LaunchTimeDB.Application.ViewModels.Users;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;

namespace LaunchTimeDB.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            this._userService = userService;
        }

        public UserDetailViewModel Insert(UserInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public UserDetailViewModel Update(UserInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public UserDetailViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDetailViewModel GetLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
