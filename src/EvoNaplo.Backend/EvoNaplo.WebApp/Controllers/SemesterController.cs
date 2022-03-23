using System.Collections.Generic;
using System.Threading.Tasks;
using EvoNaplo.Infrastructure.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EvoNaplo.ApplicationCore.Domains.Semesters.Facades;
using EvoNaplo.Infrastructure.DataAccess.Entities;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly SemesterFacade _semesterFacade;

        public SemesterController(SemesterFacade SemesterFacade)
        {
            _semesterFacade = SemesterFacade;
        }

        [HttpPost("AddSemester")]
        public IActionResult AddSemester([FromBody]SemesterEntity semester)
        {
            _semesterFacade.AddSemester(semester);
            return StatusCode(StatusCodes.Status200OK);
        }

        // List
        // GET /api/Semester/Semesters
        [HttpGet("Semesters")]
        public IEnumerable<SemesterDTO> GetSemesters()
        {
            return _semesterFacade.GetSemesters();
        }

        [HttpGet("GetSemesterById")]
        public SemesterDTO GetSemesterById(int id)
        {
            return _semesterFacade.GetSemesterById(id);
        }

        [HttpGet("GetSemesterToEditById")]
        public SemesterEntity GetSemesterToEditById(int id)
        {
            return _semesterFacade.GetSemesterToEditById(id);
        }

        //PUT
        [HttpPut("EditSemester")]
        public IActionResult EditSemester([FromBody] SemesterEntity semester)
        {
            _semesterFacade.EditSemester(semester);
            return StatusCode(StatusCodes.Status200OK);
        }

        //Delete (is-active falsera)
        // PUT /api/Semester Postman param részébe az adatok
        [HttpDelete("DELETE")]
        public IActionResult DeleteSemester(int id)
        {
            _semesterFacade.DeleteSemester(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("GetSemesterProjects")]
        public IEnumerable<ProjectDTO> GetSemesterProjects(int id)
        {
            return _semesterFacade.GetSemesterProjects(id);
        }
    }
}