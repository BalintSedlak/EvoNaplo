using EvoNaplo.Infrastructure.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNaplo.Infrastructure.DomainFacades
{
    public interface IStudentFacade
    {
        List<StudentEntity> GetAllStudent();
        StudentEntity EditStudent(StudentEntity student);
        StudentEntity GetStudentEntityById(int id);
    }
}
