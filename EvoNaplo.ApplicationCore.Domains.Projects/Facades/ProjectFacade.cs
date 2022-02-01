using EvoNaplo.ApplicationCore.Domains.Projects.Services;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.ApplicationCore.Domains.Projects.Facades
{
    public class ProjectFacade : IProjectFacade
    {
        private readonly ProjectService _projectService;
        private readonly ILogger _logger;

        public ProjectFacade(ProjectService projectService, ILogger logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        public void AddProject(ProjectEntity project)
        {
            _projectService.AddProject(project);
            _logger.LogInformation($"{project.Id} was added.");
        }

        public void DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
            _logger.LogInformation($"The project with {id} id was deleted");
        }

        public void EditProject(ProjectEntity project)
        {
            _projectService.EditProject(project);
            _logger.LogInformation($"The project with {project.Id} id was edited");
        }

        public List<ProjectDTO> GetMyProjects(int userId)
        {
            throw new NotImplementedException();
            //return _projectService.GetMyProjects(userId);
        }

        public ProjectDTO GetMyProjectThisSemester(int userId)
        {
            throw new NotImplementedException();
            //return _projectService.GetMyProjectThisSemester(userId);
        }

        public ProjectDTO GetProjectById(int id)
        {
            return _projectService.GetProjectById(id);
        }

        public IEnumerable<ProjectDTO> GetProjects()
        {
            return _projectService.GetProjects();
        }

        public IEnumerable<ProjectDTO> GetProjectsOfCurrentSemseter()
        {
            throw new NotImplementedException();
            //return _projectService.GetProjectsOfCurrentSemseter();
        }

        public ProjectEntity GetProjectToEditById(int id)
        {
            return _projectService.GetProjectToEditById(id);
        }

        public void JoinProject(int userId, int projectId)
        {
            throw new NotImplementedException();
            _logger.LogInformation($"{userId} joined to {projectId} project");
        }

        public void LeaveProject(int userId, int projectId)
        {
            throw new NotImplementedException();
            //_projectService.LeaveProject(userId, projectId);
        }
    }
}
