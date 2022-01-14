using Microsoft.AspNetCore.Mvc;
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

        public SessionController(IAuthFacade authFacade)
        {
            _authFacade = authFacade;
        }

        //TODO: Move to AuthController?
        [HttpGet]
        public IActionResult GetSession()
        {
            try
            {
                string jwt = Request.Cookies["jwt"];
                UserDTO user = _authFacade.GetUserByJwt(jwt);
                var session = _authFacade.GetSession(user);

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
