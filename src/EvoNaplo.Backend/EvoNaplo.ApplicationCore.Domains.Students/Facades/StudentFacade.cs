using EvoNaplo.ApplicationCore.Domains.Students.Services;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNaplo.ApplicationCore.Domains.Students.Facades
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
            throw new NotImplementedException();
        }

        public List<StudentEntity> GetAllStudent()
        {
            throw new NotImplementedException();
        }
    }
}
