using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.Models.DTO;

namespace EvoNaplo.Infrastructure.DomainFacades
{
    public interface IProjectFacade
    {
        IEnumerable<ProjectDTO> GetProjects();
        void AddProject(ProjectEntity project);
        IEnumerable<ProjectDTO> GetProjectsOfCurrentSemseter();
        ProjectDTO GetProjectById(int id);
        ProjectEntity GetProjectToEditById(int id);
        void EditProject(ProjectEntity project);
        void DeleteProject(int id);
        ProjectDTO GetMyProjectThisSemester(int userId);
        List<ProjectDTO> GetMyProjects(int userId);
        void JoinProject(int userId, int projectId);
        void LeaveProject(int userId, int projectId);
    }
}
