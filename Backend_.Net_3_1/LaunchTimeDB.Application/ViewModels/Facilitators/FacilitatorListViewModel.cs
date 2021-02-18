using LaunchTimeDB.Domain.Entities;
using System.Collections.Generic;

namespace LaunchTimeDB.Application.ViewModels.Facilitators
{
    public class FacilitatorListViewModel
    {
        public virtual IList<Facilitator> Facilitators { get; private set; }
        public virtual int TotalRecords { get; private set; }

        public void Load(IList<Facilitator> facilitators)
        {
            this.Facilitators = facilitators;
            this.TotalRecords = (facilitators != null) ? facilitators.Count : 0;
        }
    }
}
