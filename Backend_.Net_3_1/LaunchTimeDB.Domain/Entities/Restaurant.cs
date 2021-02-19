using LaunchTimeDB.Domain.Entities.Base;

namespace LaunchTimeDB.Domain.Entities
{
    public class Restaurant : EntityBase
    {
        public virtual string Name { get; private set; }

        public Restaurant(string name)
        {
            this.Name = name;
            AuditionCreate();
        }

        public Restaurant(long id, string name)
        {
            this.Id = id;
            this.Name = name;
            AuditionCreate();
        }

        public void Update(string name)
        {
            this.Name = name;
            AuditionUpdate();
        }
    }
}
