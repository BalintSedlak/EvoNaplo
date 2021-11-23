using EvoNaploTFS.Models.DTO;
using EvoNaploTFS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EvoNaploTFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStudentController : ControllerBase
    {
        private readonly ProjectStudentService _projectStudentService;

        public ProjectStudentController(ProjectStudentService ProjectStudentService)
        {
            _projectStudentService = ProjectStudentService;
        }

        [HttpGet("ProjectsStudents")]
        public ProjectStudentsDTO GetProjects()
        {
            return _projectStudentService.GetProjectStudents();
        }

        [HttpPut("ProjectsStudentsChanged")]
        public async Task<int> EditStudentOnProjects([FromBody] StudentToProjectDTO studentToProjectDTO)
        {
            if(_projectStudentService.ManageStudentOnProject(studentToProjectDTO))
            {
                return StatusCodes.Status200OK;
            }
            return StatusCodes.Status401Unauthorized;
        }

        [HttpPost("JoinProject")]
        public async Task<int> JoinProject([FromBody] int studentId, int projectId)
        {
            await _projectStudentService.JoinProjectAsStudent(studentId, projectId);
            return StatusCodes.Status200OK;
        }

        [HttpDelete("LeaveProject")]
        public async Task<int> LeaveProject([FromBody] int studentId, int projectId)
        {
            await _projectStudentService.LeaveProjectAsStudent(studentId, projectId);
            return StatusCodes.Status200OK;
        }
    }
}
