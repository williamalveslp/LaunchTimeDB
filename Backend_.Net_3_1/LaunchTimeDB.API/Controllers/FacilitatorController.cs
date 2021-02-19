using LaunchTimeDB.API.Controllers.Base;
using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Facilitators;
using Microsoft.AspNetCore.Mvc;

namespace LaunchTimeDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitatorController : MainController
    {
        private readonly IFacilitatorAppService _facilitatorAppService;

        public FacilitatorController(IFacilitatorAppService facilitatorAppService)
        {
            _facilitatorAppService = facilitatorAppService;
        }

        /// <summary>
        /// Insert the Facilitator.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] FacilitatorInputModel inputModel)
        {
            return ResponseOk(_facilitatorAppService.Insert(inputModel));
        }

        /// <summary>
        /// Update the Restaurant.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] FacilitatorInputModel inputModel)
        {
            return ResponseOk(_facilitatorAppService.Update(inputModel));
        }

        /// <summary>
        /// Get Facilitator by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return ResponseOk(_facilitatorAppService.GetById(id));
        }

        /// <summary>
        /// List all Facilitator.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return ResponseOk(_facilitatorAppService.GetAll());
        }

        /// <summary>
        /// Delete the Facilitator.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _facilitatorAppService.Delete(id);
            return ResponseOk(_facilitatorAppService.GetAll());
        }
    }
}
