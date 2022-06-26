using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.Infrastructure.Models.TableConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNaplo.ApplicationCore.Domains.Users.Services
{
    public class AttendanceService
    {
        private readonly IRepository<Attendance> _attendanceRepository;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<SemesterEntity> _semesterRepository;
        private readonly IRepository<ProjectEntity> _projectRepository;
        private readonly IRepository<AttendanceSheet> _attendanceSheetRepository;

        public AttendanceService(IRepository<Attendance> attendanceRepository, IRepository<UserEntity> userRepository, IRepository<SemesterEntity> semesterRepository, IRepository<ProjectEntity> projectRepository, IRepository<AttendanceSheet> attendanceSheetRepository)
        {
            _attendanceRepository = attendanceRepository;
            _userRepository = userRepository;
            _semesterRepository = semesterRepository;
            _projectRepository = projectRepository;
            _attendanceSheetRepository = attendanceSheetRepository;
        }
        public IEnumerable<AttendanceDTO> ListAttendances()
        {
            var attendances = _attendanceRepository.GetAll();
            var attendanceDTOs = new List<AttendanceDTO>();
            foreach (var attendance in attendances)
            {
                _attendanceRepository.GetById(1);
                var student = _userRepository.GetById(attendance.StudentId);
                var sheet = _attendanceSheetRepository.GetById(attendance.AttendanceSheetId);
                var attendanceDTO = new AttendanceDTO
                {
                    Name = student.LastName + student.FirstName,
                    Semester = sheet.MeetingDate.Year + " / " + (sheet.MeetingDate.Month <= 6 ? "2" : "1"),
                    Project = _projectRepository.GetById(sheet.ProjectId).ProjectName,
                    Date = sheet.MeetingDate.ToShortDateString(),
                    Status = "online" // change DB: add status prop to attendance table
                };
                attendanceDTOs.Add(attendanceDTO);
            }
            
            return attendanceDTOs;
        }
    }
}
