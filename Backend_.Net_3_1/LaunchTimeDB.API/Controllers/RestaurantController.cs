using LaunchTimeDB.API.Controllers.Base;
using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Restaurants;
using LaunchTimeDB.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace LaunchTimeDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : MainController
    {
        private readonly IRestaurantAppService _restaurantAppService;

        public RestaurantController(IRestaurantAppService restaurantAppService)
        {
            _restaurantAppService = restaurantAppService;
        }

        /// <summary>
        /// Post the Restaurant.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] RestaurantInputModel inputModel)
        {
            try
            {
                return ResponseOk(_restaurantAppService.Insert(inputModel));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message, HttpStatusCode.BadRequest));
            }
        }

        /// <summary>
        /// Update the Restaurant.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] RestaurantInputModel inputModel)
        {
            try
            {
                return ResponseOk(_restaurantAppService.Update(inputModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Restaurant by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return ResponseOk(_restaurantAppService.GetById(id));
        }

        /// <summary>
        /// List all Restaurants.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return ResponseOk(_restaurantAppService.GetAll());
        }

        /// <summary>
        /// Delete Restaurant.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _restaurantAppService.Delete(id);
                return ResponseOk(_restaurantAppService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
