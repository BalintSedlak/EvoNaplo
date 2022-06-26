using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.TableConnectors;

namespace EvoNaplo.ApplicationCore.Domains.Projects.Services
{
    public class ProjectService
    {
        private readonly IRepository<ProjectEntity> _projectRepository;

        public ProjectService(IRepository<ProjectEntity> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IEnumerable<ProjectDTO> GetProjects()
        {
            var projects = _projectRepository.GetAll();
            List<ProjectDTO> result = new List<ProjectDTO>();
            foreach (var project in projects)
            {
                result.Add(new ProjectDTO(project));
            }
            return result;
        }

        //internal IEnumerable<ProjectDTO> GetProjectsOfCurrentSemseter()
        //{
        //    var semesterList = _projectRepository.Semesters.ToList();
        //    var currentSemester = semesterList.OrderByDescending(semester => semester.Id).FirstOrDefault();
        //    if (currentSemester == null)
        //    {
        //        return new List<ProjectDTO>();
        //    }
        //    var currentSemesterId = currentSemester.Id;
        //    var projects = _projectRepository.Projects.ToList();
        //    List<ProjectDTO> result = new List<ProjectDTO>();
        //    foreach (var project in projects)
        //    {
        //        result.Add(new ProjectDTO(project));
        //    }
        //    return result.Where(project => project.SemesterId == currentSemesterId);
        //}

        internal async Task AddProject(ProjectEntity project)
        {
            //if (_projectRepository.Semesters.ToList().Count > 0)
            //{
                //project.SemesterId = _projectRepository.Semesters.Max(s => s.Id);
                _projectRepository.Add(project);
                await _projectRepository.SaveChangesAsync();
            //}
        }

        public ProjectDTO GetProjectById(int id)
        {
            var project = _projectRepository.GetAll().FirstOrDefault(u => u.Id == id);
            if (project != null)
            {
                return new ProjectDTO(project);
            }
            else
            {
                return new ProjectDTO();
            }
        }
        public ProjectEntity GetProjectToEditById(int id)
        {
            var project = _projectRepository.GetAll().FirstOrDefault(u => u.Id == id);
            if (project != null)
            {
                return new ProjectEntity(project);
            }
            else
            {
                return new ProjectEntity();
            }
        }
        public async Task<IEnumerable<ProjectEntity>> EditProject(ProjectEntity project)
        {
            var ProjectToEdit = _projectRepository.GetAll().Single(x => x.Id == project.Id);
            ProjectToEdit.ProjectName = project.ProjectName;
            ProjectToEdit.Description = project.Description;
            ProjectToEdit.SourceLink = project.SourceLink;
            _projectRepository.SaveChangesAsync();
            return _projectRepository.GetAll().ToList();
        }
        public async Task<IEnumerable<ProjectEntity>> DeleteProject(int id)
        {
            var projectToDelete = _projectRepository.GetAll().Single(x => x.Id == id);
            _projectRepository.Remove(projectToDelete);
            _projectRepository.SaveChangesAsync();
            return _projectRepository.GetAll().ToList();
        }

        //public ProjectDTO GetMyProjectThisSemester(int userId)
        //{
        //    //if (_projectRepository.Semesters.ToList().Count == 0)
        //    //{
        //    //    return new ProjectDTO();
        //    //}

        //    //var semsterId = _projectRepository.Semesters.Max(s => s.Id);
        //    //var projectIds = _projectRepository.Projects.Where(p => p.SemesterId == semsterId).Select(p => p.Id).ToList();

        //    var userProjects = _projectRepository.UserProjects.Where(up => up.UserId == userId).ToList();
        //    foreach (var up in userProjects)
        //    {
        //        if (projectIds.Contains(up.ProjectId))
        //        {
        //            return GetProjectById(up.ProjectId);
        //        }
        //    }
        //    return new ProjectDTO();
        //}

        //public List<ProjectDTO> GetMyProjects(int userId)
        //{
        //    int semsterId = -1;
        //    List<UserProject> userProjects = new List<UserProject>();
        //    List<int> projectIds = new List<int>();

        //    if (!(_projectRepository.Semesters.ToList().Count > 0 && _projectRepository.Projects.ToList().Count > 0 && _projectRepository.UserProjects.ToList().Count > 0))
        //    {
        //        return new List<ProjectDTO>();
        //    }

        //    semsterId = _projectRepository.Semesters.Max(s => s.Id);
        //    projectIds = _projectRepository.Projects.Select(p => p.Id).ToList();
        //    userProjects = _projectRepository.UserProjects.Where(up => up.UserId == userId).ToList();

        //    List<ProjectDTO> myProjects = new List<ProjectDTO>();
        //    foreach (var up in userProjects)
        //    {
        //        if (projectIds.Contains(up.ProjectId))
        //        {
        //            myProjects.Add(GetProjectById(up.ProjectId));
        //        }
        //    }
        //    return myProjects;
        //}

        //public async Task<IEnumerable<UserProject>> JoinProject(int userId, int projectId)
        //{
        //    await _projectRepository.UserProjects.AddAsync(new UserProject(userId, projectId));
        //    _projectRepository.SaveChanges();
        //    return _projectRepository.UserProjects.ToList();
        //}

        //public async Task<IEnumerable<UserProject>> LeaveProject(int userId, int projectId)
        //{
        //    var projectToLeave = _projectRepository.UserProjects.FirstOrDefault(u => u.UserId == userId && u.ProjectId == projectId);
        //    _projectRepository.Remove(projectToLeave);
        //    _projectRepository.SaveChangesAsync();
        //    return _projectRepository.UserProjects.ToList();
        //}
    }
}
