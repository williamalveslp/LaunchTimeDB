using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Users;
using LaunchTimeDB.Application.ViewModels.Users;
using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace LaunchTimeDB.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            this._userService = userService;
        }

        public UserSimpleDetailViewModel Insert(UserInputModel inputModel)
        {
            var user = new User(inputModel.UserName, inputModel.Password, inputModel.Name);
            user = _userService.Insert(user);
            return GetSimpleDetailViewModel(user);
        }

        public UserSimpleDetailViewModel Update(UserInputModel inputModel)
        {
            if (!inputModel.Id.HasValue)
                throw new Exception("Id não enviado.");

            var user = _userService.GetById((long)inputModel.Id);
            if (user == null) return null;

            user.Update(inputModel.UserName, inputModel.Password, inputModel.Name);
            user = _userService.Update(user);

            return GetSimpleDetailViewModel(user);
        }

        public UserSimpleDetailViewModel GetById(long id)
        {
            var user = _userService.GetById(id);
            return GetSimpleDetailViewModel(user);
        }

        public UserSimpleDetailViewModel GetLogin(string userName, string password)
        {
            var user = _userService.GetLogin(userName, password);
            if (user == null)
                return null;

            return GetSimpleDetailViewModel(user);
        }

        public UserListViewModel GetAll()
        {
            var allUsers = _userService.GetAll();
            return GetListViewModel(allUsers);
        }

        public void Delete(long id)
        {
            _userService.DeleteById(id);
        }

        #region .: PRIVATE METHODS :.
        private UserSimpleDetailViewModel GetSimpleDetailViewModel(User user)
        {
            var simpleDetailViewModel = new UserSimpleDetailViewModel();
            simpleDetailViewModel.Load(user.Id, user.UserName, user.Name, user.CreatedDate, user.UpdatedDate);
            return simpleDetailViewModel;
        }

        private UserListViewModel GetListViewModel(IList<User> users)
        {
            var listViewModel = new UserListViewModel();

            IList<UserSimpleDetailViewModel> userSimple = new List<UserSimpleDetailViewModel>();
            foreach (var item in users)
            {
                var userSimpleDetailViewModel = GetSimpleDetailViewModel(item);
                userSimple.Add(userSimpleDetailViewModel);
            }
            listViewModel.Load(userSimple);
            return listViewModel;
        }
        #endregion
    }
}
