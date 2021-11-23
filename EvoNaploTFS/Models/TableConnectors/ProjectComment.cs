using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Models.TableConnectors
{
    public class ProjectComment
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        [ForeignKey("CommenterId")]
        public int CommenterId { get; set; }
    }
}
