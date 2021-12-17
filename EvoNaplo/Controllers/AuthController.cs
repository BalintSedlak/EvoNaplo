using EvoNaplo.Services;
using EvoNaplo.Helpers;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginService loginService;
        private readonly JwtService jwtService;
        private readonly UserService userService;

        public AuthController(LoginService _loginService, JwtService _jwtService, UserService _userService)
        {
            loginService = _loginService;
            jwtService = _jwtService;
            userService = _userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            User user = loginService.LogInUser(loginDTO);
            if (user == null)
            {
                return BadRequest(new { message = "No such user" });
            }

            if (BCrypt.Net.BCrypt.Verify(loginDTO.password, user.Password))
            {
                var jwt = jwtService.GenerateToken(user.Id);

                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true
                });
                return Ok(new
                {
                    message="success"
                });
            }
            else
            {
                return BadRequest(new { message = "Bad password" });
            }
        }

        [HttpGet("User")]
        public IActionResult GetRole()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = userService.GetUserById(userId);

                return Ok(user);
            }
            catch (Exception)
            {

                return Unauthorized();
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
