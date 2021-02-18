using LaunchTimeDB.Domain.Entities;

namespace LaunchTimeDB.Application.ViewModels.Users
{
    public class UserDetailViewModel
    {
        public virtual User User { get; private set; }

        public void Load(User user)
        {
            this.User = user;
        }
    }
}
