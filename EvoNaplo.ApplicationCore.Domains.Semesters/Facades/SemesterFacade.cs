using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.WebApp.Services;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.ApplicationCore.Domains.Semesters.Facades
{
    public class SemesterFacade : ISemesterFacade
    {
        private readonly SemesterService _semesterService;
        private readonly ILogger _logger;

        public SemesterFacade(SemesterService semesterService,ILogger logger)
        {
            _semesterService = semesterService;
            _logger = logger;
        }

        public void AddSemester(SemesterEntity semester)
        {
            _semesterService.AddSemester(semester);
            _logger.LogInformation($"{semester.Id} semester was added");
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
            _logger.LogInformation($"{semester.Id} semester was edited");
        }

        public void DeleteSemester(int id)
        {
            _semesterService.DeleteSemester(id);
            _logger.LogInformation($"{id} semester was deleted");
        }

        public IEnumerable<ProjectDTO> GetSemesterProjects(int id)
        {
            throw new NotImplementedException();
        }
    }
}
