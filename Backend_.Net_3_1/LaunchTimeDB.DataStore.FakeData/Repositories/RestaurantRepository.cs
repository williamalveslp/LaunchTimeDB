using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace LaunchTimeDB.DataStore.FakeData
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public Restaurant Insert(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public Restaurant Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public IList<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
