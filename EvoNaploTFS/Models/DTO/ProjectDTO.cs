namespace EvoNaploTFS.Models.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public string SourceLink { get; set; }

        public string Technologies { get; set; }

        public int SemesterId { get; set; }

        public ProjectDTO()
        {
            Id = -1;
        }

        public ProjectDTO(Project project)
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