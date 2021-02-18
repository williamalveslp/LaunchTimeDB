using LaunchTimeDB.Domain.Entities;
using System.Collections.Generic;

namespace LaunchTimeDB.Application.ViewModels.Restaurants
{
    public class RestaurantListViewModel
    {
        public virtual IList<Restaurant> Restaurants { get; private set; }
        public virtual int TotalRecords { get; private set; }

        public void Load(IList<Restaurant> restaurants)
        {
            this.Restaurants = restaurants;
            this.TotalRecords = (restaurants != null) ? restaurants.Count : 0;
        }
    }
}
