using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.Services
{
    public class SemesterService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly ILogger<AttendanceSheetService> _logger;

        public SemesterService(ILogger<AdminService> logger,EvoNaploContext EvoNaploContext)
        {
            _logger = logger;
            _evoNaploContext = EvoNaploContext;
        }
        public async Task<IEnumerable<Semester>> AddSemester(Semester semester)
        {
            _logger.LogInformation($"{semester} hozzaadasa kovetkezik.")
            await _evoNaploContext.Semesters.AddAsync(semester);
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"Semester hozzaadasa megtortent.")
            return _evoNaploContext.Semesters.ToList();
        }
        public IEnumerable<SemesterDTO> GetSemesters()
        {
            var semesters = _evoNaploContext.Semesters;
            List<SemesterDTO> result = new List<SemesterDTO>();
            foreach(var semester in semesters)
            {
                result.Add(new SemesterDTO(semester));
            }
            return result;
        }
        public SemesterDTO GetSemesterById(int id)
        {
            var semester = _evoNaploContext.Semesters.FirstOrDefault(u => u.Id == id);
            if (semester != null)
            {
                return new SemesterDTO(semester);
            }
            else
            {
                return new SemesterDTO();
            }
        }
        public Semester GetSemesterToEditById(int id)
        {
            var semester = _evoNaploContext.Semesters.FirstOrDefault(u => u.Id == id);
            if (semester != null)
            {
                return new Semester(semester);
            }
            else
            {
                return new Semester();
            }
        }
        public async Task<IEnumerable<Semester>> EditSemester(Semester semester)
        {
            _logger.LogInformation($"{semester} modositasa kovetkezik.")
            var SemesterToEdit = await _evoNaploContext.Semesters.FindAsync(semester.Id);
            SemesterToEdit.StartDate = semester.StartDate;
            SemesterToEdit.EndDate = semester.EndDate;
            SemesterToEdit.IsAppliable = semester.IsAppliable;
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"Semester modositasa megtortent.")
            return _evoNaploContext.Semesters.ToList();
        }

        public async Task<IEnumerable<Semester>> DeleteSemester(int id)
        {
            _logger.LogInformation($"{id} semester torlese kovetkezik.")
            var semesterToDelete = await _evoNaploContext.Semesters.FindAsync(id);
            _evoNaploContext.Remove(semesterToDelete);
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"Semester torlese megtortent.")
            return _evoNaploContext.Semesters.ToList();
        }

        public IEnumerable<ProjectDTO> GetSemesterProjects(int id)
        {
            var semesterProjects = _evoNaploContext.Projects.Where(c => c.SemesterId == id);
            List<ProjectDTO> result = new List<ProjectDTO>();
            foreach (var project in semesterProjects)
            {
                result.Add(new ProjectDTO(project));
            }
            return result;
        }

        public async Task JoinSemester(int id)
        {

            await _evoNaploContext.UsersOnSemester.AddAsync(new EvoNaplo.Models.TableConnectors.UsersOnSemester(id,_evoNaploContext.Semesters.Max(s => s.Id)));
            _evoNaploContext.SaveChanges();
        }
    }
}
