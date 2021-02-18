using System;

namespace LaunchTimeDB.Application.InputModels.Facilitators
{
    public class FacilitatorInputModel
    {
        public int? Id { get; set; }
        public int RestaurantId { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
