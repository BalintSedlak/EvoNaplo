using EvoNaplo.ApplicationCore.Domains.Comments.Services;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.TableConnectors;

namespace EvoNaplo.ApplicationCore.Domains.Comments.Facades
{
    public class CommentFacade : ICommentFacade
    {
        private readonly CommentService _commentService;

        public CommentFacade(CommentService commentService)
        {
            _commentService = commentService;
        }

        public IEnumerable<CommentDTO> GetStudentComments(int id)
        {
            throw new NotImplementedException();
        }

        public void AddStudentComment(StudentComment studentComment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> GetProjectComments(int id)
        {
            throw new NotImplementedException();
        }

        public void EditStudentComment(CommentDTO studentComment)
        {
            throw new NotImplementedException();
        }

        public void EditProjectComment(CommentDTO projectComment)
        {
            throw new NotImplementedException();
        }

        public void AddProjectComment(ProjectComment projectComment)
        {
            throw new NotImplementedException();
        }
    }
}
