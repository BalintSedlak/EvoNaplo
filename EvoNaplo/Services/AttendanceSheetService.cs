using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoNaplo.Services
{
    public class AttendanceSheetService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly ILogger<AttendanceSheetService> _logger;

        public AttendanceSheetService(ILogger<AdminService> logger,EvoNaploContext EvoNaploContext)
        {
            _logger = logger;
            _evoNaploContext = EvoNaploContext;
        }

        internal IEnumerable<AttendanceSheetDTO> GetAttendanceSheets()
        {
            var attendanceSheets = _evoNaploContext.AttendanceSheets;
            List<AttendanceSheetDTO> result = new List<AttendanceSheetDTO>();
            foreach (var attendanceSheet in attendanceSheets)
            {
                result.Add(new AttendanceSheetDTO(attendanceSheet));
            }
            return result;
        }

        internal async Task EditAttendanceSheet(AttendanceSheet attendanceSheet)
        {
            _logger.LogInformation($"{attendanceSheet} modositasa kovetkezik.")
            var AttendanceSheetToEdit = await _evoNaploContext.AttendanceSheets.FindAsync(attendanceSheet.Id);
            AttendanceSheetToEdit.MeetingDate = attendanceSheet.MeetingDate;
            AttendanceSheetToEdit.ProjectId = attendanceSheet.ProjectId;
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"AttendanceSheet modositasa megtortent.")
        }

        internal async Task AddAttendanceSheet(AttendanceSheet attendanceSheet)
        {
            _logger.LogInformation($"{attendanceSheet} hozzaadasa kovetkezik.")
            await _evoNaploContext.AttendanceSheets.AddAsync(attendanceSheet);
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"AttendanceSheet hozzaadasa megtortent.")
        }

        internal async Task DeleteAttendanceSheet(int id)
        {
            _logger.LogInformation($"{id} AttendanceSheet torlese kovetkezik.")
            var attendanceSheetToDelete = await _evoNaploContext.AttendanceSheets.FindAsync(id);
            _evoNaploContext.Remove(attendanceSheetToDelete);
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"AttendanceSheet torlese megtortent.")
        }
    }
}
