using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.Models.DTO;

namespace EvoNaplo.Infrastructure.DomainFacades
{
    public interface ISemesterFacade
    {
        void AddSemester(SemesterEntity semester);
        IEnumerable<SemesterDTO> GetSemesters();
        SemesterDTO GetSemesterById(int id);
        SemesterEntity GetSemesterToEditById(int id);
        void EditSemester(SemesterEntity semester);
        void DeleteSemester(int id);
        IEnumerable<ProjectDTO> GetSemesterProjects(int id);
    }
}
