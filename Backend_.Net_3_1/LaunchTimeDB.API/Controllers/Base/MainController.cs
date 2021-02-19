using LaunchTimeDB.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace LaunchTimeDB.API.Controllers.Base
{
    /// <summary>
    /// Controller base for each API.
    /// </summary>
    public abstract class MainController : ControllerBase
    {
        /// <summary>
        /// Use for 2xx (Ok) responses.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected IActionResult ResponseOk<T>(T entity)
        {
            // TODO: Remove this try catch and replace to Notification Pattern.
            try
            {
                return Ok(new ResponseData<T>(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message, HttpStatusCode.BadRequest));
            }
        }

        /// <summary>
        /// User for BadRequest.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected IActionResult ResponseWithError<T>(ILogger<T> logger, Exception ex)
        {
            LogError(logger, ex);

            ErrorResponse viewModel = new ErrorResponse(ex.Message, HttpStatusCode.BadRequest);
            return BadRequest(viewModel);
        }

        private void LogError<T>(ILogger<T> logger, Exception ex)
        {
            logger.LogError($"Error: {ex.Message}\r\nStackTrace: {ex.StackTrace}\r\n\r\n");
        }
    }

    public class ResponseData<T>
    {
        public T Data { get; private set; }

        public ResponseData(T data)
        {
            this.Data = data;
        }
    }
}
