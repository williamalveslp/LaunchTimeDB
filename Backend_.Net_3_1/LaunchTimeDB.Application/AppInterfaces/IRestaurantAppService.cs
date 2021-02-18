using LaunchTimeDB.Application.InputModels.Restaurants;
using LaunchTimeDB.Application.ViewModels.Restaurants;

namespace LaunchTimeDB.Application.AppInterfaces
{
    public interface IRestaurantAppService
    {
        RestaurantDetailViewModel GetById(int id);

        RestaurantListViewModel GetAll();

        RestaurantDetailViewModel Insert(RestaurantInputModel inputModel);

        RestaurantDetailViewModel Update(RestaurantInputModel inputModel);

        void Delete(int id);
    }
}
