using Microsoft.AspNetCore.Mvc;
using EvoNaplo.WebApp.Services;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Exceptions;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IAuthFacade _authFacade;
        private readonly SessionService _sessionService;

        public SessionController(IAuthFacade authFacade,SessionService sessionService)
        {
            _authFacade = authFacade;
            _sessionService = sessionService;
        }

        //TODO: Move to AuthController?
        [HttpGet]
        public IActionResult GetSession()
        {
            try
            {
                string jwt = Request.Cookies["jwt"];
                UserDTO user = _authFacade.GetUserByJwt(jwt);
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
