using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
            entity.SetIdFake(GetNextId());

            if (!IsValid(entity.Id, entity.Name, true))
                return null;

            return _restaurantRepository.Insert(entity);
        }

        public Restaurant Update(Restaurant entity)
        {
            if (!IsValid(entity.Id, entity.Name, false))
                return null;

            return _restaurantRepository.Update(entity);
        }

        public void DeleteById(long entityId)
        {
            _restaurantRepository.DeleteById(entityId);
        }

        public IList<Restaurant> GetAll()
        {
            return _restaurantRepository.GetAll();
        }

        public Restaurant GetById(long entityId)
        {
            return _restaurantRepository.GetById(entityId);
        }

        public bool IsValid(long id, string name, bool isNew)
        {
            var allRestaurants = GetAll();

            string messageErrors = string.Empty;

            Restaurant hasSameId = null;
            if (isNew)
                hasSameId = allRestaurants.Where(f => f.Id == id).FirstOrDefault();

            if (hasSameId != null)
                messageErrors += $"Já existe com este mesmo Id.\r\n";

            Restaurant hasSameRestaurantName = null;
            if (isNew)
                hasSameRestaurantName = allRestaurants.Where(f => f.Name.ToLower() == name.ToLower()).FirstOrDefault();
            else
                hasSameRestaurantName = allRestaurants.Where(f => (f.Id != id) && (f.Name.ToLower() == name.ToLower())).FirstOrDefault();

            if (hasSameRestaurantName != null)
                messageErrors += $"Nome '{name}' já existe.\r\n";

            if (!string.IsNullOrEmpty(messageErrors))
                throw new Exception(messageErrors);

            return true;
        }

        public long GetNextId()
        {
            var allRestaurants = _restaurantRepository.GetAll();

            if (allRestaurants.Count <= 0)
                return 1;

            return allRestaurants.Max(f => f.Id) + 1;
        }
    }
}
