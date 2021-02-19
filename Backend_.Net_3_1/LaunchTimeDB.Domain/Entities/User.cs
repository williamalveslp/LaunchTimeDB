using LaunchTimeDB.Domain.Entities.Base;

namespace LaunchTimeDB.Domain.Entities
{
    public class User : EntityBase
    {
        public virtual string UserName { get; private set; }
        public virtual string Password { get; private set; }
        public virtual string Name { get; private set; }

        public User(string userName, string password, string name)
        {
            this.UserName = userName;
            this.Password = password;
            this.Name = name;

            AuditionCreate();
        }

        public User(long id, string userName, string password, string name)
        {
            this.Id = id;
            this.UserName = userName;
            this.Password = password;
            this.Name = name;

            AuditionCreate();
        }

        public void Update(string userName, string password, string name)
        {
            this.UserName = userName;
            this.Password = password;
            this.Name = name;

            AuditionUpdate();
        }
    }
}
