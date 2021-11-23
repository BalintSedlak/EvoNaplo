using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using EvoNaploTFS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaploTFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly MentorService _mentorService;

        public MentorController(MentorService MentorService)
        {
            _mentorService = MentorService;
        }

        [HttpPost]
        public async Task<int> PostAddMentor([FromBody] User user)
        {
            await _mentorService.AddMentor(user);
            return StatusCodes.Status200OK;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetMentor()
        {
            return _mentorService.ListMentors();
        }
    }
}