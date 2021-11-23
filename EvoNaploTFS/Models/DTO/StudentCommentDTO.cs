using EvoNaploTFS.Models.TableConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Models.DTO
{
    public class StudentCommentDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Commenter { get; set; }

        public StudentCommentDTO()
        {
            Id = -1;
        }

        public StudentCommentDTO(StudentComment studentComment, string commenter)
        {
            Id = studentComment.Id;
            Comment = studentComment.Comment;
            Commenter = commenter;
        }
    }
}
