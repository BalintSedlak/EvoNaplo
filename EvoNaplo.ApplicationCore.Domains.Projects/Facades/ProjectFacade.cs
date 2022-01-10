using EvoNaplo.ApplicationCore.Domains.Projects.Services;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;

namespace EvoNaplo.ApplicationCore.Domains.Projects.Facades
{
    public class ProjectFacade : IProjectFacade
    {
        private readonly ProjectService _projectService;

        public ProjectFacade(ProjectService projectService)
        {
            _projectService = projectService;
        }

        public void AddProject(ProjectEntity project)
        {
            _projectService.AddProject(project);
        }

        public void DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
        }

        public void EditProject(ProjectEntity project)
        {
            _projectService.EditProject(project);
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
        }

        public void LeaveProject(int userId, int projectId)
        {
            throw new NotImplementedException();
            //_projectService.LeaveProject(userId, projectId);
        }
    }
}
