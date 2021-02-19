using LaunchTimeDB.API.Controllers.Base;
using LaunchTimeDB.Application.AppInterfaces;
using LaunchTimeDB.Application.InputModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace LaunchTimeDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            this._userAppService = userAppService;
        }

        /// <summary>
        /// Post the User.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] UserInputModel inputModel)
        {
            return ResponseOk(_userAppService.Insert(inputModel));
        }

        /// <summary>
        /// Post the User.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn([FromBody] UserInputModel inputModel)
        {
            return ResponseOk(_userAppService.GetLogin(inputModel.UserName, inputModel.Password));
        }

        /// <summary>
        /// Update the User.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] UserInputModel inputModel)
        {
            return ResponseOk(_userAppService.Update(inputModel));
        }

        /// <summary>
        /// Get User by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return ResponseOk(_userAppService.GetById(id));
        }

        /// <summary>
        /// List all Users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return ResponseOk(_userAppService.GetAll());
        }

        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _userAppService.Delete(id);
            return ResponseOk(_userAppService.GetAll());
        }
    }
}
