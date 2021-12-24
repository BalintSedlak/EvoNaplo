using EvoNaplo.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public AuthController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginViewModel loginDTO)
        {
            try
            {
                string jwt = _userFacade.Login(loginDTO);

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
                UserDTO user = _userFacade.GetUserByJwt(jwt);

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
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "successfully logged out"
            });
        }
    }
}
