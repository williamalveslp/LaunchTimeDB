using LaunchTimeDB.Application.InputModels.Users;
using LaunchTimeDB.Application.ViewModels.Users;

namespace LaunchTimeDB.Application.AppInterfaces
{
    public interface IUserAppService
    {
        UserSimpleDetailViewModel GetById(long id);

        UserSimpleDetailViewModel GetLogin(string userName, string password);

        UserSimpleDetailViewModel Insert(UserInputModel inputModel);

        UserSimpleDetailViewModel Update(UserInputModel inputModel);

        UserListViewModel GetAll();

        void Delete(long id);
    }
}
