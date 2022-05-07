using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.Models.DTO;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.WebApp.Services
{
    public class SemesterService
    {
        private readonly IRepository<SemesterEntity> _semesterRepository;
        private readonly ILogger logger;

        public SemesterService(IRepository<SemesterEntity> semesterRepository)
        {
            _semesterRepository = semesterRepository;
            
        }

        public async Task<IEnumerable<SemesterEntity>> AddSemester(SemesterEntity semester)
        {
            
            _semesterRepository.Add(semester);
            await _semesterRepository.SaveChangesAsync();
            return _semesterRepository.GetAll().ToList();
        }
        public IEnumerable<SemesterDTO> GetSemesters()
        {
            var semesters = _semesterRepository.GetAll();
            List<SemesterDTO> result = new List<SemesterDTO>();
            foreach(var semester in semesters)
            {
                result.Add(new SemesterDTO(semester));
            }
            return result;
        }
        public SemesterDTO GetSemesterById(int id)
        {
            var semester = _semesterRepository.GetAll().FirstOrDefault(u => u.Id == id);
            if (semester != null)
            {
                return new SemesterDTO(semester);
            }
            else
            {
                return new SemesterDTO();
            }
        }
        public SemesterEntity GetSemesterToEditById(int id)
        {
            var semester = _semesterRepository.GetAll().FirstOrDefault(u => u.Id == id);
            if (semester != null)
            {
                return new SemesterEntity(semester);
            }
            else
            {
                return new SemesterEntity();
            }
        }
        public async Task<IEnumerable<SemesterEntity>> EditSemester(SemesterEntity semester)
        {
            var SemesterToEdit = _semesterRepository.GetAll().Single(x => x.Id == semester.Id);
            SemesterToEdit.StartDate = semester.StartDate;
            SemesterToEdit.EndDate = semester.EndDate;
            SemesterToEdit.IsAppliable = semester.IsAppliable;
            await _semesterRepository.SaveChangesAsync();
            return _semesterRepository.GetAll().ToList();
        }

        public async Task<IEnumerable<SemesterEntity>> DeleteSemester(int id)
        {
            var semesterToDelete = _semesterRepository.GetAll().Single(x => x.Id == id);
            _semesterRepository.Remove(semesterToDelete);
            await _semesterRepository.SaveChangesAsync();
            return _semesterRepository.GetAll().ToList();
        }

        //public IEnumerable<ProjectDTO> GetSemesterProjects(int id)
        //{
        //    var semesterProjects = _semesterRepository.Projects.Where(c => c.SemesterId == id);
        //    List<ProjectDTO> result = new List<ProjectDTO>();
        //    foreach (var project in semesterProjects)
        //    {
        //        result.Add(new ProjectDTO(project));
        //    }
        //    return result;
        //}

        //public async Task JoinSemester(int id)
        //{
        //    await _semesterRepository.UsersOnSemester.AddAsync(new EvoNaplo.Infrastructure.Models.TableConnectors.UsersOnSemester(id,_semesterRepository.Semesters.Max(s => s.Id)));
        //    _semesterRepository.SaveChanges();
        //}
    }
}
