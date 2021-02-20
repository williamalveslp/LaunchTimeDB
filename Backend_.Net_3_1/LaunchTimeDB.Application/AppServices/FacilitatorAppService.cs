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
        private readonly IUserService _userService;
        private readonly IRestaurantService _restaurantService;

        public FacilitatorAppService(IFacilitatorService facilitatorService, IUserService userService
                                    , IRestaurantService restaurantService)
        {
            this._facilitatorService = facilitatorService;
            this._userService = userService;
            this._restaurantService = restaurantService;
        }

        public FacilitatorDetailViewModel Insert(FacilitatorInputModel inputModel)
        {
            FieldsValidations(inputModel);

            var facilitator = new Facilitator(inputModel.RestaurantId, inputModel.LaunchDate, inputModel.UserId);
            facilitator = _facilitatorService.Insert(facilitator);
            return GetDetailViewModel(facilitator);
        }

        public FacilitatorDetailViewModel Update(FacilitatorInputModel inputModel)
        {
            FieldsValidations(inputModel);

            if (!inputModel.Id.HasValue)
                throw new Exception("Id não enviado.");

            var facilitator = _facilitatorService.GetById((long)inputModel.Id);
            if (facilitator == null)
                throw new Exception("Facilitador não encontrado.");

            facilitator.Update(inputModel.RestaurantId, inputModel.LaunchDate, inputModel.UserId);
            return GetDetailViewModel(facilitator);
        }

        public FacilitatorListViewModel GetAll()
        {
            var allFacilitators = _facilitatorService.GetAll();
            return GetListViewModel(allFacilitators);
        }

        public FacilitatorDetailViewModel GetById(long id)
        {
            var facilitator = _facilitatorService.GetById(id);
            return GetDetailViewModel(facilitator);
        }

        public void Delete(long id)
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

        private void FieldsValidations(FacilitatorInputModel inputModel)
        {
            var restaurant = _restaurantService.GetById(inputModel.RestaurantId);
            if (restaurant == null)
                throw new Exception("Restaurante não encontrado.");

            var user = _userService.GetById(inputModel.UserId);
            if (user == null)
                throw new Exception("Usuário não encontrado.");
        }
        #endregion
    }
}
