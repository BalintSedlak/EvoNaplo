using EvoNaplo.DataAccessLayer;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using EvoNaploTFS.Models.TableConnectors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Services
{
    public class ProjectService
    {
        private readonly EvoNaploContext _evoNaploContext;

        public ProjectService(EvoNaploContext EvoNaploContext)
        {
            _evoNaploContext = EvoNaploContext;
        }

        public IEnumerable<ProjectDTO> GetProjects()
        {
            var projects = _evoNaploContext.Projects;
            List<ProjectDTO> result = new List<ProjectDTO>();
            foreach (var project in projects)
            {
                result.Add(new ProjectDTO(project));
            }
            return result;
        }

        internal IEnumerable<ProjectDTO> GetProjectsOfCurrentSemseter()
        {
            var semesterList = _evoNaploContext.Semesters.ToList();
            var currentSemester = semesterList.OrderByDescending(semester => semester.Id).FirstOrDefault();
            if (currentSemester == null)
            {
                return new List<ProjectDTO>();
            }
            var currentSemesterId = currentSemester.Id;
            var projects = _evoNaploContext.Projects.ToList();
            List<ProjectDTO> result = new List<ProjectDTO>();
            foreach (var project in projects)
            {
                result.Add(new ProjectDTO(project));
            }
            return result.Where(project => project.SemesterId == currentSemesterId);
        }

        internal async Task AddProject(Project project)
        {
            if (_evoNaploContext.Semesters.ToList().Count > 0)
            {
                project.SemesterId = _evoNaploContext.Semesters.Max(s => s.Id);
                await _evoNaploContext.Projects.AddAsync(project);
                _evoNaploContext.SaveChanges();
            }
        }

        public ProjectDTO GetProjectById(int id)
        {
            var project = _evoNaploContext.Projects.FirstOrDefault(u => u.Id == id);
            if (project != null)
            {
                return new ProjectDTO(project);
            }
            else
            {
                return new ProjectDTO();
            }
        }
        public Project GetProjectToEditById(int id)
        {
            var project = _evoNaploContext.Projects.FirstOrDefault(u => u.Id == id);
            if (project != null)
            {
                return new Project(project);
            }
            else
            {
                return new Project();
            }
        }
        public async Task<IEnumerable<Project>> EditProject(Project project)
        {
            var ProjectToEdit = await _evoNaploContext.Projects.FindAsync(project.Id);
            ProjectToEdit.ProjectName = project.ProjectName;
            ProjectToEdit.Description = project.Description;
            ProjectToEdit.SourceLink = project.SourceLink;
            ProjectToEdit.Technologies = project.Technologies;
            _evoNaploContext.SaveChanges();
            return _evoNaploContext.Projects.ToList();
        }
        public async Task<IEnumerable<Project>> DeleteProject(int id)
        {
            var projectToDelete = await _evoNaploContext.Projects.FindAsync(id);
            _evoNaploContext.Remove(projectToDelete);
            _evoNaploContext.SaveChanges();
            return _evoNaploContext.Projects.ToList();
        }

        public ProjectDTO GetMyProjectThisSemester(int userId)
        {
            if (_evoNaploContext.Semesters.ToList().Count == 0)
            {
                return new ProjectDTO();
            }
            var semsterId = _evoNaploContext.Semesters.Max(s => s.Id);
            var projectIds = _evoNaploContext.Projects.Where(p => p.SemesterId == semsterId).Select(p => p.Id).ToList();

            var userProjects = _evoNaploContext.UserProjects.Where(up => up.UserId == userId).ToList();
            foreach (var up in userProjects)
            {
                if (projectIds.Contains(up.ProjectId))
                {
                    return GetProjectById(up.ProjectId);
                }
            }
            return new ProjectDTO();
        }

        public List<ProjectDTO> GetMyProjects(int userId)
        {
            int semsterId = -1;
            List<UserProject> userProjects = new List<UserProject>();
            List<int> projectIds = new List<int>();

            if (!(_evoNaploContext.Semesters.ToList().Count > 0 && _evoNaploContext.Projects.ToList().Count > 0 && _evoNaploContext.UserProjects.ToList().Count > 0))
            {
                return new List<ProjectDTO>();
            }

            semsterId = _evoNaploContext.Semesters.Max(s => s.Id);
            projectIds = _evoNaploContext.Projects.Select(p => p.Id).ToList();
            userProjects = _evoNaploContext.UserProjects.Where(up => up.UserId == userId).ToList();

            List<ProjectDTO> myProjects = new List<ProjectDTO>();
            foreach (var up in userProjects)
            {
                if (projectIds.Contains(up.ProjectId))
                {
                    myProjects.Add(GetProjectById(up.ProjectId));
                }
            }
            return myProjects;
        }

        public async Task<IEnumerable<UserProject>> JoinProject(int userId, int projectId)
        {
            await _evoNaploContext.UserProjects.AddAsync(new UserProject(userId, projectId));
            _evoNaploContext.SaveChanges();
            return _evoNaploContext.UserProjects.ToList();
        }

        public async Task<IEnumerable<UserProject>> LeaveProject(int userId, int projectId)
        {
            var projectToLeave = _evoNaploContext.UserProjects.FirstOrDefault(u => u.UserId == userId && u.ProjectId == projectId);
            _evoNaploContext.Remove(projectToLeave);
            _evoNaploContext.SaveChanges();
            return _evoNaploContext.UserProjects.ToList();
        }
    }
}
