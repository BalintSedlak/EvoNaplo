using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.WebApp.Services;

namespace EvoNaplo.ApplicationCore.Domains.Auth.Facades
{
    public class SemesterFacade : ISemesterFacade
    {
        private readonly ISemesterFacade _semesterFacade;
        private readonly SemesterService _semesterService;

        public SemesterFacade(ISemesterFacade semesterFacade, SemesterService semesterService)
        {
            _semesterFacade = semesterFacade;
            _semesterService = semesterService;
        }

        public void AddSemester(SemesterEntity semester)
        {
            _semesterService.AddSemester(semester);
        }

        public IEnumerable<SemesterDTO> GetSemesters()
        {
            return _semesterService.GetSemesters();
        }

        public SemesterDTO GetSemesterById(int id)
        {
            return _semesterService.GetSemesterById(id);
        }

        public SemesterEntity GetSemesterToEditById(int id)
        {
            return _semesterService.GetSemesterToEditById(id);
        }

        public void EditSemester(SemesterEntity semester)
        {
            _semesterService.EditSemester(semester);
        }

        public void DeleteSemester(int id)
        {
            _semesterService.DeleteSemester(id);
        }

        public IEnumerable<ProjectDTO> GetSemesterProjects(int id)
        {
            throw new NotImplementedException();
        }
    }
}
