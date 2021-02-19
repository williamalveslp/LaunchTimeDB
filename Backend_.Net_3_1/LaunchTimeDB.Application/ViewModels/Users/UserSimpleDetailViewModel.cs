using System;

namespace LaunchTimeDB.Application.ViewModels.Users
{
    public class UserSimpleDetailViewModel
    {
        public virtual long Id { get; private set; }
        public virtual string UserName { get; private set; }
        public virtual string Name { get; private set; }
        public virtual DateTime CreateDate { get; private set; }
        public virtual DateTime UpdateDate { get; private set; }

        public void Load(long id, string userName, string name, DateTime createDate, DateTime updateDate)
        {
            this.Id = id;
            this.UserName = userName;
            this.Name = name;
            this.CreateDate = createDate;
            this.UpdateDate = updateDate;
        }
    }
}
