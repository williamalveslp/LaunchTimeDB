using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using LaunchTimeDB.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace LaunchTimeDB.Domain.Services.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this._restaurantRepository = restaurantRepository;
        }

        public Restaurant Insert(Restaurant entity)
        {
            return _restaurantRepository.Insert(entity);
        }

        public Restaurant Update(Restaurant entity)
        {
            return _restaurantRepository.Update(entity);
        }

        public void DeleteById(int entityId)
        {
            _restaurantRepository.DeleteById(entityId);
        }

        public IList<Restaurant> GetAll()
        {
            return _restaurantRepository.GetAll();
        }

        public Restaurant GetById(int entityId)
        {
            return _restaurantRepository.GetById(entityId);
        }
    }
}
