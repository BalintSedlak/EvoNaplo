using EvoNaplo.DataAccessLayer;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoNaploTFS.Services
{
    public class AttendanceSheetService
    {
        private readonly EvoNaploContext _evoNaploContext;

        public AttendanceSheetService(EvoNaploContext EvoNaploContext)
        {
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
            var AttendanceSheetToEdit = await _evoNaploContext.AttendanceSheets.FindAsync(attendanceSheet.Id);
            AttendanceSheetToEdit.MeetingDate = attendanceSheet.MeetingDate;
            AttendanceSheetToEdit.ProjectId = attendanceSheet.ProjectId;
            _evoNaploContext.SaveChanges();
        }

        internal async Task AddAttendanceSheet(AttendanceSheet attendanceSheet)
        {
            await _evoNaploContext.AttendanceSheets.AddAsync(attendanceSheet);
            _evoNaploContext.SaveChanges();
        }

        internal async Task DeleteAttendanceSheet(int id)
        {
            var attendanceSheetToDelete = await _evoNaploContext.AttendanceSheets.FindAsync(id);
            _evoNaploContext.Remove(attendanceSheetToDelete);
            _evoNaploContext.SaveChanges();
        }
    }
}
