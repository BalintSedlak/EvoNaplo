using System.Collections.Generic;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectFacade _projectFacade;

        public ProjectController(IProjectFacade ProjectFacade)
        {
            _projectFacade = ProjectFacade;
        }

        [HttpGet("Projects")]
        public IEnumerable<ProjectDTO> GetProjects()
        {
            return _projectFacade.GetProjects();
        }

        [HttpPost("AddProject")]
        public IActionResult PostAddProject([FromBody] ProjectEntity project)
        {
            _projectFacade.AddProject(project);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("ProjectsOfCurrentSemester")]
        public IEnumerable<ProjectDTO> GetProjectsOfCurrentSemester()
        {
            return _projectFacade.GetProjectsOfCurrentSemseter();
        }

        [HttpGet("GetProjectById")]
        public ProjectDTO GetProjectById(int id)
        {
            return _projectFacade.GetProjectById(id);
        }

        [HttpGet("GetProjectToEditById")]
        public ProjectEntity GetProjectToEditById(int id)
        {
            return _projectFacade.GetProjectToEditById(id);
        }
        //PUT
        [HttpPut("EditProject")]
        public IActionResult EditProject([FromBody] ProjectEntity project)
        {
            _projectFacade.EditProject(project);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("DELETE")]
        public IActionResult DeleteProject(int id)
        {
            _projectFacade.DeleteProject(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("MyProjectThisSemester")]
        public ProjectDTO GetMyProjectThisSemester(int userId)
        {
            return _projectFacade.GetMyProjectThisSemester(userId);
        }

        [HttpGet("MyProjects")]
        public List<ProjectDTO> GetMyProjects(int userId)
        {
            return _projectFacade.GetMyProjects(userId);
        }

        [HttpPost("JoinProject")]
        public IActionResult JoinProject(int userId,int projectId)
        {
            _projectFacade.JoinProject(userId, projectId);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("LeaveProject")]
        public IActionResult LeaveProject(int userId, int projectId)
        {
            _projectFacade.LeaveProject(userId, projectId);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}