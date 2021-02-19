using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Restaurants;
using LaunchTimeDB.Application.ViewModels.Restaurants;
using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace LaunchTimeDB.Application.AppServices
{
    public class RestaurantAppService : IRestaurantAppService
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantAppService(IRestaurantService restaurantService)
        {
            this._restaurantService = restaurantService;
        }

        public RestaurantDetailViewModel Insert(RestaurantInputModel inputModel)
        {
            var restaurant = new Restaurant(inputModel.Name);
            restaurant = _restaurantService.Insert(restaurant);
            return GetDetailViewModel(restaurant);
        }

        public RestaurantDetailViewModel Update(RestaurantInputModel inputModel)
        {
            if (!inputModel.Id.HasValue)
                throw new Exception("Id não enviado.");

            var restaurant = _restaurantService.GetById((long)inputModel.Id);
            if (restaurant == null) return null;

            restaurant.Update(inputModel.Name);
            restaurant = _restaurantService.Update(restaurant);

            return GetDetailViewModel(restaurant);
        }

        public RestaurantListViewModel GetAll()
        {
            var allRestaurants = _restaurantService.GetAll();
            return GetListViewModel(allRestaurants);
        }

        public RestaurantDetailViewModel GetById(int id)
        {
            var restaurant = _restaurantService.GetById(id);
            return GetDetailViewModel(restaurant);
        }

        public void Delete(int id)
        {
            _restaurantService.DeleteById(id);
        }

        #region .: PRIVATE METHODS :.
        private RestaurantDetailViewModel GetDetailViewModel(Restaurant restaurant)
        {
            var detailViewModel = new RestaurantDetailViewModel();
            detailViewModel.Load(restaurant);
            return detailViewModel;
        }

        private RestaurantListViewModel GetListViewModel(IList<Restaurant> restaurants)
        {
            var listViewModel = new RestaurantListViewModel();
            listViewModel.Load(restaurants);
            return listViewModel;
        }
        #endregion
    }
}
