using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvoNaploTFS.Helpers;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using EvoNaploTFS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaploTFS.Controllers
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
        public IEnumerable<UserDTO> GetAdmin()
        {
            return _adminService.ListAdmins();
        }
    }
}