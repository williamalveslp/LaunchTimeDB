using System;

namespace LaunchTimeDB.Domain.Entities.Base
{
    public class Auditory
    {
        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime UpdatedDate { get; set; }

        protected void AuditionCreate()
        {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }

        protected void AuditionUpdate()
        {
            this.UpdatedDate = DateTime.Now;
        }
    }
}
