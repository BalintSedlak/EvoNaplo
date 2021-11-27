using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using EvoNaplo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceSheetController
    {
        private readonly AttendanceSheetService _attendanceSheetService;

        public AttendanceSheetController(AttendanceSheetService attendanceSheetService)
        {
            _attendanceSheetService = attendanceSheetService;
        }

        [HttpGet("AttendanceSheets")]
        public IEnumerable<AttendanceSheetDTO> GetAttendanceSheets()
        {
            return _attendanceSheetService.GetAttendanceSheets();
        }

        [HttpPost("AddAttendanceSheet")]
        public async Task<int> PostAddAttendanceSheet([FromBody] AttendanceSheet attendanceSheet)
        {
            await _attendanceSheetService.AddAttendanceSheet(attendanceSheet);
            return StatusCodes.Status200OK;
        }

        [HttpPut("EditAttendanceSheet")]
        public async Task<int> EditAttendanceSheet([FromBody] AttendanceSheet attendanceSheet)
        {
            await _attendanceSheetService.EditAttendanceSheet(attendanceSheet);
            return StatusCodes.Status200OK;
        }

        [HttpDelete("DELETE")]
        public async Task<int> DeleteAttendanceSheet(int id)
        {
            await _attendanceSheetService.DeleteAttendanceSheet(id);
            return StatusCodes.Status200OK;
        }
    }
}
