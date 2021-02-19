using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaunchTimeDB.DataStore.FakeData
{
    public class FacilitatorRepository : IFacilitatorRepository
    {
        private static IList<Facilitator> _facilitatorsDataList = new List<Facilitator>()
        {
            new Facilitator(1, 3, DateTime.Now.AddDays(2)),
            new Facilitator(2, 4, DateTime.Now.AddDays(4)),
            new Facilitator(3, 5, DateTime.Now.AddDays(3))
        };

        public Facilitator Insert(Facilitator entity)
        {
            _facilitatorsDataList.Add(entity);
            return entity;
        }

        public Facilitator Update(Facilitator entity)
        {
            Facilitator facilitator = null;
            foreach (var item in _facilitatorsDataList)
            {
                if (item.Id == entity.Id)
                {
                    item.Update(entity.RestaurantId, entity.LaunchDate);
                    facilitator = item;
                    break;
                }
            }
            return facilitator;
        }

        public IList<Facilitator> GetAll()
        {
            return _facilitatorsDataList.OrderBy(f => f.Id).ToList();
        }

        public Facilitator GetById(long entityId)
        {
            return _facilitatorsDataList.Where(f => f.Id == entityId).FirstOrDefault();
        }

        public void DeleteById(long entityId)
        {
            var restaurant = GetById(entityId);
            if (restaurant == null) return;
            _facilitatorsDataList.Remove(restaurant);
        }
    }
}
