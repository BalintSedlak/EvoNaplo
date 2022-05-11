using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoNaplo.Infrastructure.Models.TableConnectors
{
    public class StudentsOnSemester
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [ForeignKey("SemesterId")]
        public int SemesterId { get; set; }

        public StudentsOnSemester()
        {
        }
        public StudentsOnSemester(int studentId,int semesterId)
        {
            StudentId = studentId;
            SemesterId = semesterId;
        }
    }
}
