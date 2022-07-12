using EvoNaplo.Infrastructure.DataAccess.Entities;
using System.Collections.Generic;

namespace EvoNaplo.Infrastructure.Models.DTO
{
    public class ProjectStudentsDTO
    {
        public List<ProjectUser> usersOnProject { get; set; } = new List<ProjectUser>();
        public List<ProjectUser> usersNotOnProject { get; set; } = new List<ProjectUser>();
        public List<ColumnProject> columnProjects { get; set; } = new List<ColumnProject>();
        public List<string> columnOrder { get; set; } = new List<string>();
    }

    public class ProjectUser
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ProjectUser(UserDTO user)
        {
            Id = user.Id.ToString();
            Name = user.Name;
        }
    }

    public class ColumnProject
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<string> ProjectStudentIds { get; set; } = new List<string>();

        public ColumnProject(ProjectEntity project)
        {
            Id = project.Id.ToString();
            Title = project.ProjectName;
        }
    }
}
