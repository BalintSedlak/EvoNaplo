using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using EvoNaploTFS.Models.TableConnectors;
using EvoNaploTFS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService UserService)
        {
            _userService = UserService;
        }
        
        [HttpGet("Students")]
        public IEnumerable<UserDTO> GetStudent()
        {
            return _userService.ListStudents();
        }

        [HttpGet("Mentors")]
        public IEnumerable<UserDTO> GetMentor()
        {
            return _userService.ListActiveMentors();
        }

        [HttpGet("Admins")]
        public IEnumerable<UserDTO> GetAdmin()
        {
            return _userService.ListActiveAdmins();
        }

        [HttpGet("GetUserById")]
        public UserDTO GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("GetUserToEditById")]
        public User GetUserToEditById(int id)
        {
            return _userService.GetUserToEditById(id);
        }

        //PUT
        [HttpPut("EditUser")]
        public async Task<int> EditUser([FromBody]User user)
        {
            await _userService.EditUser(user);
            return StatusCodes.Status200OK;
        }

        [HttpPut("EditUserRole")]
        public async Task<int> EditUserRole([FromBody] User user, User.RoleTypes newRole)
        {
            await _userService.EditUserRole(user, newRole);
            return StatusCodes.Status200OK;
        }

        //Delete
        [HttpDelete("DELETE")]
        public async Task<int> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return StatusCodes.Status200OK;
        }
    }
}
