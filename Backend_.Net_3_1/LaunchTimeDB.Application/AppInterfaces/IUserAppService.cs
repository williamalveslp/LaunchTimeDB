using LaunchTimeDB.Application.InputModels.Users;
using LaunchTimeDB.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchTimeDB.Application.AppInterfaces
{
    public interface IUserAppService
    {
        UserDetailViewModel GetById(int id);

        UserDetailViewModel GetLogin(string userName, string password);

        UserDetailViewModel Insert(UserInputModel inputModel);

        UserDetailViewModel Update(UserInputModel inputModel);

        void Delete(int id);
    }
}
