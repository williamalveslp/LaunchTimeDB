using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace LaunchTimeDB.DataStore.FakeData
{
    public class FacilitatorRepository : IFacilitatorRepository
    {
        public Facilitator Insert(Facilitator entity)
        {
            throw new NotImplementedException();
        }

        public Facilitator Update(Facilitator entity)
        {
            throw new NotImplementedException();
        }

        public IList<Facilitator> GetAll()
        {
            throw new NotImplementedException();
        }

        public Facilitator GetById(int entityId)
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
