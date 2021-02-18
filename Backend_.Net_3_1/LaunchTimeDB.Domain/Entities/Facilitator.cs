using LaunchTimeDB.Domain.Entities.Base;
using System;

namespace LaunchTimeDB.Domain.Entities
{
    public class Facilitator : EntityBase
    {
        public virtual long RestaurantId { get; private set; }
        public virtual DateTime LaunchDate { get; private set; }

        public Facilitator(long restaurantId, DateTime launchDate)
        {
            this.RestaurantId = restaurantId;
            this.LaunchDate = launchDate;

            AuditionCreate();
        }
    }
}
