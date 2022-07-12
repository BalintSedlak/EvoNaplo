using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentFacade _studentFacade;

        public StudentController(IStudentFacade studentFacade)
        {
            _studentFacade = studentFacade;
        }

        [HttpGet("Students")]
        public IEnumerable<StudentEntity> GetStudents()
        {
            return _studentFacade.GetAllStudent();
        }

        [HttpGet("GetStudentById")]
        public StudentEntity GetStudent(int id)
        {
            return _studentFacade.GetStudentEntityById(id);
        }

        [HttpPut("EditStudent")]
        public async Task<StudentEntity> EditStudent(StudentEntity updatedStudent)
        {
            return await _studentFacade.EditStudent(updatedStudent);
        }
    }
}
