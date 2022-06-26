using EvoNaplo.ApplicationCore.Domains.Users.Services;
using EvoNaplo.Infrastructure.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController
    {
        private readonly AttendanceService _attendancService;

        public AttendanceController(AttendanceService attendancService)
        {
            _attendancService = attendancService;
        }
        [HttpGet("Attendances")]
        public IEnumerable<AttendanceDTO> GetAttendances()
        {
            return _attendancService.ListAttendances();
        }
    }
}
