using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaunchTimeDB.Domain.Services.Services
{
    public class FacilitatorService : IFacilitatorService
    {
        private readonly IFacilitatorRepository _facilitatorRepository;

        public FacilitatorService(IFacilitatorRepository facilitatorRepository)
        {
            this._facilitatorRepository = facilitatorRepository;
        }

        public Facilitator Insert(Facilitator entity)
        {
            entity.SetIdFake(GetNextId());
            return _facilitatorRepository.Insert(entity);
        }

        public Facilitator Update(Facilitator entity)
        {
            return _facilitatorRepository.Update(entity);
        }

        public IList<Facilitator> GetAll()
        {
            return _facilitatorRepository.GetAll();
        }

        public Facilitator GetById(long entityId)
        {
            return _facilitatorRepository.GetById(entityId);
        }

        public void DeleteById(long entityId)
        {
            _facilitatorRepository.DeleteById(entityId);
        }

        public bool IsValidToCreate(long id, long restaurantId, DateTime launchDate)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(long id, long restaurantId, DateTime launchDate, bool isNew)
        {
            throw new NotImplementedException();
        }

        public long GetNextId()
        {
            var allFacilitators = _facilitatorRepository.GetAll();

            if (allFacilitators.Count <= 0)
                return 1;

            return allFacilitators.Max(f => f.Id) + 1;
        }
    }
}
