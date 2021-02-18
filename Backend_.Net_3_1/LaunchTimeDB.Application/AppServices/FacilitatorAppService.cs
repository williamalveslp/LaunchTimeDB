using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Facilitators;
using LaunchTimeDB.Application.ViewModels.Facilitators;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;

namespace LaunchTimeDB.Application.AppServices
{
    public class FacilitatorAppService : IFacilitatorAppService
    {
        private readonly IFacilitatorService _facilitatorService;

        public FacilitatorAppService(IFacilitatorService facilitatorService)
        {
            this._facilitatorService = facilitatorService;
        }

        public FacilitatorDetailViewModel Insert(FacilitatorInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public FacilitatorDetailViewModel Update(FacilitatorInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public FacilitatorListViewModel GetAll()
        {
            throw new NotImplementedException();
        }

        public FacilitatorDetailViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
