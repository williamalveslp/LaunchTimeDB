using System;

namespace LaunchTimeDB.Application.InputModels.Facilitators
{
    public class FacilitatorInputModel
    {
        public long? Id { get; set; }
        public long RestaurantId { get; set; }
        public DateTime LaunchDate { get; set; }

        public long UserId { get; set; }
    }
}
