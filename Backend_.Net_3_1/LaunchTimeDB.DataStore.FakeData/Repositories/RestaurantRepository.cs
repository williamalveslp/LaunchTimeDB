using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaunchTimeDB.DataStore.FakeData
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private static IList<Restaurant> _restaurantsDataList = new List<Restaurant>()
        {
            new Restaurant(1, "Atelier das Massas"),
            new Restaurant(2, "Forno a Lenha"),
            new Restaurant(3, "Panela de Ferro"),
            new Restaurant(4, "Delícias na Panela"),
            new Restaurant(5, "Sabores na Panela"),
            new Restaurant(6, "Costela no Roletchê"),
            new Restaurant(7, "El Tonel"),
            new Restaurant(8, "Sambô"),
            new Restaurant(9, "Daimu"),
            new Restaurant(10, "Baalbek"),
            new Restaurant(11, "Bistro"),
            new Restaurant(12, "Lancheria do Parque")
        };

        public Restaurant Insert(Restaurant entity)
        {
            _restaurantsDataList.Add(entity);
            return entity;
        }

        public Restaurant Update(Restaurant entity)
        {
            Restaurant restaurant = null;
            foreach (var item in _restaurantsDataList)
            {
                if (item.Id == entity.Id)
                {
                    item.Update(entity.Name);
                    restaurant = item;
                    break;
                }
            }
            return restaurant;
        }

        public IList<Restaurant> GetAll()
        {
            return _restaurantsDataList.OrderBy(f => f.Name).ToList();
        }

        public Restaurant GetById(long entityId)
        {
            return _restaurantsDataList.Where(f => f.Id == entityId).FirstOrDefault();
        }

        public void DeleteById(long entityId)
        {
            var user = GetById(entityId);
            if (user == null) return;
            _restaurantsDataList.Remove(user);
        }
    }
}
