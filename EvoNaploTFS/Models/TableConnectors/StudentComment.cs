using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Models.TableConnectors
{
    public class StudentComment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("CommenterId")]
        public int CommenterId { get; set; }
    }
}
