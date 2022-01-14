using EvoNaplo.Infrastructure.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using EvoNaplo.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using EvoNaplo.Infrastructure.DomainFacades;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthFacade _authFacade;

        public AuthController(IAuthFacade authFacade)
        {
            _authFacade = authFacade;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginViewModel loginDTO)
        {
            //TODO: Move to Service 
            try
            {
                string jwt = _authFacade.Login(loginDTO);

                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true
                });
                return Ok(new
                {
                    message = "success"
                });
            }
            catch (ServiceException ex)
            {
                var statuscode = StatusCode(ex.HttpStatusCode.ConvertToInt(), ex.Message);
                return statuscode;
            }
        }

        [HttpGet("User")]
        public IActionResult GetRole()
        {
            try
            {
                string jwt = Request.Cookies["jwt"];
                UserDTO user = _authFacade.GetUserByJwt(jwt);

                return Ok(user);
            }
            catch (ServiceException ex)
            {
                var statuscode = StatusCode(ex.HttpStatusCode.ConvertToInt(), ex.Message);
                return statuscode;
            }
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            //TODO: Move to Service 
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "successfully logged out"
            });
        }
    }
}
