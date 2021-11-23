using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Models.TableConnectors
{
    public class UserProject
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }

        public UserProject()
        {

        }

        public UserProject(int userId, int projectId)
        {
            UserId = userId;
            ProjectId = projectId;
        }
    }
}
