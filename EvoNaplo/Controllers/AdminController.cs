using System.Collections.Generic;
using System.Threading.Tasks;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using EvoNaplo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService AdminService)
        {
            _adminService = AdminService;
        }

        [HttpPost]
        public async Task<int> PostAddAdmin([FromBody] User user)
        {
            await _adminService.AddAdmin(user);
            return StatusCodes.Status200OK;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetAdmins()
        {
            return _adminService.ListAdmins();
        }
    }
}