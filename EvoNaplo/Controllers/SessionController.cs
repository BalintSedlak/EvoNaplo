using System;
using Microsoft.AspNetCore.Mvc;
using EvoNaplo.Services;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Exceptions;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IUserFacade _userFacade;
        private readonly SessionService _sessionService;

        public SessionController(IUserFacade userFacade,SessionService sessionService)
        {
            _userFacade = userFacade;
            _sessionService = sessionService;
        }

        //TODO: Move to AuthController?
        [HttpGet]
        public IActionResult GetSession()
        {
            try
            {
                string jwt = Request.Cookies["jwt"];
                UserDTO user = _userFacade.GetUserByJwt(jwt);
                var session = _sessionService.GetSessionDTO(user);

                return Ok(session);
            }
            catch (ServiceException ex)
            {
                var statuscode = StatusCode(ex.HttpStatusCode.ConvertToInt(), ex.Message);
                return statuscode;
            }
        }
    }
}
