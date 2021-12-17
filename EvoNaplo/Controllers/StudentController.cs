using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService StudentService)
        {
            _studentService = StudentService;
        }

        [HttpPost("AddStudent")]
        public async Task<int> PostAddStudent([FromBody]User user)
        {
            await _studentService.AddStudent(user);
            return StatusCodes.Status200OK;
        }

        [HttpGet("EmailExists")]
        public bool EmailExists(string email)
        {
            return _studentService.EmailExists(email);
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetStudent()
        {
            return _studentService.ListStudents();
        }

        ////PUT
        //// api/Student/edit jsonben paramból id és bodyból studentDto
        //[HttpPut("edit")]
        //public async Task<int> PutEditStudent(int id, StudentDto studentDto)
        //{
        //    await _studentService.EditStudent(id, studentDto);
        //    return StatusCodes.Status200OK;
        //}

        ////PUT
        //// api/Student/inactivate jsonben paramból id
        //[HttpPut("inactivate")]
        //public async Task<int> PutInactivateStudent(int id)
        //{
        //    await _studentService.InactivateStudent(id);
        //    return StatusCodes.Status200OK;
        //}

        //Delete
        // api/Student/delete jsonben paramból id
        [HttpDelete("DELETE")]
        public async Task<int> DeleteUser(int id)
        {
            await _studentService.DeleteUser(id);
            return StatusCodes.Status200OK;
        }
    }
}