using System.Collections.Generic;
using System.Threading.Tasks;
using EvoNaplo.Services;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly SemesterService _semesterService;

        public SemesterController(SemesterService SemesterService)
        {
            _semesterService = SemesterService;
        }

        [HttpPost("AddSemester")]
        public async Task<int> AddSemester([FromBody]Semester semester)
        {
            await _semesterService.AddSemester(semester);
            return StatusCodes.Status200OK;
        }

        // List
        // GET /api/Semester/Semesters
        [HttpGet("Semesters")]
        public IEnumerable<SemesterDTO> GetSemesters()
        {
            return _semesterService.GetSemesters();
        }

        [HttpGet("GetSemesterById")]
        public SemesterDTO GetSemesterById(int id)
        {
            return _semesterService.GetSemesterById(id);
        }

        [HttpGet("GetSemesterToEditById")]
        public Semester GetSemesterToEditById(int id)
        {
            return _semesterService.GetSemesterToEditById(id);
        }

        //PUT
        [HttpPut("EditSemester")]
        public async Task<int> EditSemester([FromBody] Semester semester)
        {
            await _semesterService.EditSemester(semester);
            return StatusCodes.Status200OK;
        }

        //Delete (is-active falsera)
        // PUT /api/Semester Postman param részébe az adatok
        [HttpDelete("DELETE")]
        public async Task<int> DeleteSemester(int id)
        {
            await _semesterService.DeleteSemester(id);
            return StatusCodes.Status200OK;
        }

        [HttpGet("GetSemesterProjects")]
        public IEnumerable<ProjectDTO> GetSemesterProjects(int id)
        {
            return _semesterService.GetSemesterProjects(id);
        }

        [HttpPost("JoinSemester")]
        public async Task JoinSemester(int id)
        {
            await _semesterService.JoinSemester(id);
        }
    }
}