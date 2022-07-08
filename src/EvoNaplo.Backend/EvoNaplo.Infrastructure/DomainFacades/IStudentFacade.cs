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
        IEnumerable<StudentEntity> GetAllStudent();
        Task<StudentEntity> EditStudent(StudentEntity student);
        StudentEntity GetStudentEntityById(int id);
    }
}
