using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Facilitators;
using LaunchTimeDB.Application.ViewModels.Facilitators;
using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

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
            var facilitator = new Facilitator(inputModel.RestaurantId, inputModel.LaunchDate);
            facilitator = _facilitatorService.Insert(facilitator);
            return GetDetailViewModel(facilitator);
        }

        public FacilitatorDetailViewModel Update(FacilitatorInputModel inputModel)
        {
            if (!inputModel.Id.HasValue)
                throw new Exception("Id não enviado.");

            var facilitator = _facilitatorService.GetById((long)inputModel.Id);
            if (facilitator == null) return null;

            facilitator.Update(inputModel.RestaurantId, inputModel.LaunchDate);
            return GetDetailViewModel(facilitator);
        }

        public FacilitatorListViewModel GetAll()
        {
            var allFacilitators = _facilitatorService.GetAll();
            return GetListViewModel(allFacilitators);
        }

        public FacilitatorDetailViewModel GetById(int id)
        {
            var facilitator = _facilitatorService.GetById(id);
            return GetDetailViewModel(facilitator);
        }

        public void Delete(int id)
        {
            _facilitatorService.DeleteById(id);
        }

        #region .: PRIVATE METHODS :.
        private FacilitatorDetailViewModel GetDetailViewModel(Facilitator facilitator)
        {
            var detailViewModel = new FacilitatorDetailViewModel();
            detailViewModel.Load(facilitator);
            return detailViewModel;
        }

        private FacilitatorListViewModel GetListViewModel(IList<Facilitator> users)
        {
            var listViewModel = new FacilitatorListViewModel();
            listViewModel.Load(users);
            return listViewModel;
        }
        #endregion
    }
}
