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
    }
}
