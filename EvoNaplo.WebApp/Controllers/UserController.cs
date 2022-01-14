using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.ApplicationCore.Domains.Users.Facades;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UserController(UserFacade userFacade)
        {
            _userFacade = userFacade;
        }
        
        [HttpGet("Students")]
        public async Task<IEnumerable<UserDTO>> GetStudentAsync()
        {
            return await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Student);
        }

        [HttpGet("Mentors")]
        public async Task<IEnumerable<UserDTO>> GetMentorAsync()
        {
            return await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Mentor);
        }

        [HttpGet("Admins")]
        public async Task<IEnumerable<UserDTO>> GetAdminAsync()
        {
            return await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Admin);
        }

        [HttpGet("GetUserById")]
        public UserDTO GetUserById(int id)
        {
            return _userFacade.GetUser(id);
        }

        [HttpGet("GetUserToEditById")]
        public UserDTO GetUserToEditById(int id)
        {
            return _userFacade.GetUserById(id);
        }

        //PUT
        [HttpPut("EditUser")]
        public async Task<int> EditUser([FromBody]UserViewModel user)
        {
            await _userFacade.UpdateUserAsync(user);
            return StatusCodes.Status200OK;
        }

        [HttpPut("EditUserRole")]
        public async Task<int> EditUserRole([FromBody] UserViewModel user, RoleType newRole)
        {
            await _userFacade.SetUserRole(user, newRole);
            return StatusCodes.Status200OK;
        }

        //Delete
        [HttpDelete("DELETE")]
        public async Task<int> DeleteUser(int id)
        {
            await _userFacade.DeleteUserAsync(id);
            return StatusCodes.Status200OK;
        }
    }
}
