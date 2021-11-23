using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoNaploTFS.Models.TableConnectors
{
    public class UsersOnSemester
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("SemesterId")]
        public int SemesterId { get; set; }

        public UsersOnSemester()
        {
        }
        public UsersOnSemester(int userId,int semesterId)
        {
            UserId = userId;
            SemesterId = semesterId;
        }
    }
}
