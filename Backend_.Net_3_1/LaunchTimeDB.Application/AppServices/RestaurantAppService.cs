using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Restaurants;
using LaunchTimeDB.Application.ViewModels.Restaurants;
using LaunchTimeDB.Domain.Interfaces.Services;
using System;

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
            throw new NotImplementedException();
        }

        public RestaurantDetailViewModel Update(RestaurantInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public RestaurantListViewModel GetAll()
        {
            throw new NotImplementedException();
        }

        public RestaurantDetailViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
