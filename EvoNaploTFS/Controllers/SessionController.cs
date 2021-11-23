using System;
using Microsoft.AspNetCore.Mvc;
using EvoNaploTFS.Helpers;
using EvoNaploTFS.Services;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {


        private readonly JwtService jwtService;
        private readonly UserService userService;
        private readonly SessionService sessionService;

        public SessionController(JwtService _jwtService, UserService _userService,SessionService _sessionService)
        {
            jwtService = _jwtService;
            userService = _userService;
            sessionService = _sessionService;
        }

        [HttpGet]
        public IActionResult GetSession()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = userService.GetUserToEditById(userId);

                var session = sessionService.GetSessionDTO(user);
                return Ok(session);
            }
            catch (Exception)
            {

                return Unauthorized();
            }
        }
    }
}
