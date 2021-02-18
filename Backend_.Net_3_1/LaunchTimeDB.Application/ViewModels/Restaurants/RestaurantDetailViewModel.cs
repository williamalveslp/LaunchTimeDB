using LaunchTimeDB.Domain.Entities;

namespace LaunchTimeDB.Application.ViewModels.Restaurants
{
    public class RestaurantDetailViewModel
    {
        public virtual Restaurant Restaurant { get; private set; }

        public void Load(Restaurant restaurant)
        {
            this.Restaurant = restaurant;
        }
    }
}
