using System.Collections.Generic;
using System.Threading.Tasks;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public AdminController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost]
        public async Task<int> PostAddAdmin([FromBody] User user)
        {
            await _userFacade.AddUserAsync(user);
            return StatusCodes.Status200OK;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAdmin()
        {
            return await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Admin);
        }
    }
}