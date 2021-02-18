using LaunchTimeDB.Domain.Entities;

namespace LaunchTimeDB.Application.ViewModels.Facilitators
{
   public class FacilitatorDetailViewModel
    {
        public virtual Facilitator Facilitator { get; private set; }

        public void Load(Facilitator facilitator)
        {
            this.Facilitator = facilitator;
        }
    }
}
