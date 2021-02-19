using System.Collections.Generic;

namespace LaunchTimeDB.Application.ViewModels.Users
{
    public class UserListViewModel
    {
        public virtual IList<UserSimpleDetailViewModel> Users { get; private set; }
        public virtual int TotalRecords { get; private set; }

        public void Load(IList<UserSimpleDetailViewModel> users)
        {
            this.Users = users;
            this.TotalRecords = (users != null) ? users.Count : 0;
        }
    }
}
