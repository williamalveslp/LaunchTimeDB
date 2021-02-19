namespace LaunchTimeDB.Domain.Entities.Base
{
    public abstract class EntityBase : Auditory
    {
        public virtual long Id { get; set; }

        public void SetIdFake(long id)
        {
            this.Id = id;
        }
    }
}
