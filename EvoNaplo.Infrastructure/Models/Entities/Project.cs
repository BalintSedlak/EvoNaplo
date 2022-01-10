using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoNaplo.Infrastructure.Models.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string SourceLink { get; set; }
        public string Technologies { get; set; }
        [ForeignKey("SemesterId")]
        public int SemesterId { get; set; }
        public Project()
        {

        }

        public Project(Project project)
        {
            Id = project.Id;
            ProjectName = project.ProjectName;
            Description = project.Description;
            SourceLink = project.SourceLink;
            Technologies = project.Technologies;
            SemesterId = project.SemesterId;
        }
    }
}
