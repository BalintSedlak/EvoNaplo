using EvoNaplo.ApplicationCore.Domains.Users.Services;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;

namespace EvoNaplo.ApplicationCore.Domains.Users.Facades
{
    public class StudentFacade : IStudentFacade
    {
        private readonly StudentService _studentService;

        public StudentFacade(StudentService studentService)
        {
            _studentService = studentService;
        }
        public StudentEntity EditStudent(StudentEntity student)
        {
            return _studentService.UpdateStudent(student);
        }

        public IEnumerable<StudentEntity> GetAllStudent()
        {
            return _studentService.ListStudents();
        }

        public StudentEntity GetStudentEntityById(int id)
        {
            return _studentService.GetStudentById(id);
        }
    }
}
