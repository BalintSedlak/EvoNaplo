using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Models.TableConnectors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.Services
{
    public class CommentService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly IUserFacade _userFacade;

        public CommentService(EvoNaploContext EvoNaploContext, IUserFacade userFacade)
        {
            _evoNaploContext = EvoNaploContext;
            _userFacade = userFacade;
        }

        internal async Task AddStudentComment(StudentComment studentComment)
        {
            await _evoNaploContext.StudentComments.AddAsync(studentComment);
            _evoNaploContext.SaveChanges();
        }

        internal async Task AddProjectComment(ProjectComment projectComment)
        {
            await _evoNaploContext.ProjectComments.AddAsync(projectComment);
            _evoNaploContext.SaveChanges();
        }

        internal async Task EditStudentComment(CommentDTO studentComment)
        {
            var studentCommentToEdit = await _evoNaploContext.StudentComments.FindAsync(studentComment.Id);
            studentCommentToEdit.Comment = studentComment.Comment;
            _evoNaploContext.SaveChanges();
        }

        internal async Task EditProjectComment(CommentDTO projectComment)
        {
            var projectCommentToEdit = await _evoNaploContext.ProjectComments.FindAsync(projectComment.Id);
            projectCommentToEdit.Comment = projectComment.Comment;
            _evoNaploContext.SaveChanges();
        }

        public IEnumerable<CommentDTO> GetStudentComments(int id)
        {
            var comments = _evoNaploContext.StudentComments.Where(c => c.UserId == id);
            List<StudentComment> commentsCopy = new List<StudentComment>();
            foreach (var comment in comments)
            {
                commentsCopy.Add(comment);
            }
            List<CommentDTO> result = new List<CommentDTO>();
            foreach (var comment in commentsCopy)
            {
                var commenter = _userFacade.GetAllUser().Result.Single(u => u.Id == comment.CommenterId);
                string commenterName = $"{commenter.Name}";
                result.Add(new CommentDTO(comment.Comment, comment.UserId,commenter.Id,$"{commenter.Name}" ));
            }
            return result;
        }

        public IEnumerable<CommentDTO> GetProjectComments(int id)
        {
            var comments = _evoNaploContext.ProjectComments.Where(c => c.CommenterId == id);
            List<ProjectComment> commentsCopy = new List<ProjectComment>();
            foreach (var comment in comments)
            {
                commentsCopy.Add(comment);
            }
            List<CommentDTO> result = new List<CommentDTO>();
            foreach (var comment in commentsCopy)
            {
                var commenter = _userFacade.GetAllUser().Result.FirstOrDefault(u => u.Id == comment.CommenterId);
                string commenterName = $"{commenter.Name}";
                result.Add(new CommentDTO(comment.Comment, comment.CommenterId, commenter.Id, $"{commenter.Name}"));
            }
            return result;
        }
    }
}
