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
            try
            {
                _semesterService.AddSemester(semester);
                _logger.LogInformation($"{semester.Id} semester was edited.");
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                    _logger.LogInformation($"{semester.Id} semester was added");
                }
                throw;
            }
            
            
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
            try
            {
                _semesterService.EditSemester(semester);
                _logger.LogInformation($"{semester.Id} semester was edited.");
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                    _logger.LogInformation($"Failed to edit {semester.Id} semester");
                }
                throw;
            }
            
        }

        public void DeleteSemester(int id)
        {
            try
            {
                _semesterService.DeleteSemester(id);
                _logger.LogInformation($"{id} semester was deleted.");
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                    _logger.LogInformation($"Failed to delete {id} semester");
                }
                throw;
            }
        }

        public IEnumerable<ProjectDTO> GetSemesterProjects(int id)
        {
            throw new NotImplementedException();
        }
    }
}
