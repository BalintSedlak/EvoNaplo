using System.Collections.Generic;
using System.Threading.Tasks;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IUserFacade _userFacade;
        private readonly IAuthFacade _authFacade;

        public MentorController(IUserFacade userFacade, IAuthFacade authFacade)
        {
            _userFacade = userFacade;
            _authFacade = authFacade;
        }

        [HttpPost]
        public IActionResult PostAddMentor([FromBody] UserViewModel user)
        {
            _authFacade.RegisterNewUser(user);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetMentor()
        {
            return await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Mentor);
        }
    }
}