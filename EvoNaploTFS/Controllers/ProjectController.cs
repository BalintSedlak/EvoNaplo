using System.Collections.Generic;
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
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService ProjectService)
        {
            _projectService = ProjectService;
        }

        [HttpGet("Projects")]
        public IEnumerable<ProjectDTO> GetProjects()
        {
            return _projectService.GetProjects();
        }

        [HttpPost("AddProject")]
        public async Task<int> PostAddProject([FromBody] Project project)
        {
            await _projectService.AddProject(project);
            return StatusCodes.Status200OK;
        }

        [HttpGet("ProjectsOfCurrentSemester")]
        public IEnumerable<ProjectDTO> GetProjectsOfCurrentSemester()
        {
            return _projectService.GetProjectsOfCurrentSemseter();
        }

        [HttpGet("GetProjectById")]
        public ProjectDTO GetProjectById(int id)
        {
            return _projectService.GetProjectById(id);
        }

        [HttpGet("GetProjectToEditById")]
        public Project GetProjectToEditById(int id)
        {
            return _projectService.GetProjectToEditById(id);
        }
        //PUT
        [HttpPut("EditProject")]
        public async Task<int> EditProject([FromBody] Project project)
        {
            await _projectService.EditProject(project);
            return StatusCodes.Status200OK;
        }

        [HttpDelete("DELETE")]
        public async Task<int> DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);
            return StatusCodes.Status200OK;
        }

        [HttpGet("MyProjectThisSemester")]
        public ProjectDTO GetMyProjectThisSemester(int userId)
        {
            return _projectService.GetMyProjectThisSemester(userId);
        }

        [HttpGet("MyProjects")]
        public List<ProjectDTO> GetMyProjects(int userId)
        {
            return _projectService.GetMyProjects(userId);
        }

        [HttpPost("JoinProject")]
        public async Task<int> JoinProject(int userId,int projectId)
        {
            await _projectService.JoinProject(userId, projectId);
            return StatusCodes.Status200OK;
        }

        [HttpDelete("LeaveProject")]
        public async Task<int> LeaveProject(int userId,int projectId)
        {
            await _projectService.LeaveProject(userId, projectId);
            return StatusCodes.Status200OK;
        }
    }
}