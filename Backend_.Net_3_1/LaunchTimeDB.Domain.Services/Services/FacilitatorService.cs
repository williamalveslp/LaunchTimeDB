using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using LaunchTimeDB.Domain.Interfaces.Services;
using System.Collections.Generic;

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

        public Facilitator GetById(int entityId)
        {
            return _facilitatorRepository.GetById(entityId);
        }

        public void DeleteById(int entityId)
        {
            _facilitatorRepository.DeleteById(entityId);
        }
    }
}
