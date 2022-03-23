using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DomainFacades;

namespace EvoNaplo.ApplicationCore.Domains.Comments.Services
{
    public class CommentService
    {
        //private readonly IRepository<CommentEntity> _commentRepository;
        //private readonly IUserFacade _userFacade;

        public CommentService(/*IRepository<CommentEntity> commentRepository*/ /*, IUserFacade userFacade*/)
        {
            //_commentRepository = commentRepository;
            //_userFacade = userFacade;
        }

        //internal async Task AddStudentComment(StudentComment studentComment)
        //{
        //    await _evoNaploContext.StudentComments.AddAsync(studentComment);
        //    _evoNaploContext.SaveChanges();
        //}

        //internal async Task AddProjectComment(ProjectComment projectComment)
        //{
        //    await _evoNaploContext.ProjectComments.AddAsync(projectComment);
        //    _evoNaploContext.SaveChanges();
        //}

        //internal async Task EditStudentComment(CommentDTO studentComment)
        //{
        //    var studentCommentToEdit = await _evoNaploContext.StudentComments.FindAsync(studentComment.Id);
        //    studentCommentToEdit.Comment = studentComment.Comment;
        //    _evoNaploContext.SaveChanges();
        //}

        //internal async Task EditProjectComment(CommentDTO projectComment)
        //{
        //    var projectCommentToEdit = await _evoNaploContext.ProjectComments.FindAsync(projectComment.Id);
        //    projectCommentToEdit.Comment = projectComment.Comment;
        //    _evoNaploContext.SaveChanges();
        //}

        //public IEnumerable<CommentDTO> GetStudentComments(int id)
        //{
        //    var comments = _evoNaploContext.StudentComments.Where(c => c.UserId == id);
        //    List<StudentComment> commentsCopy = new List<StudentComment>();
        //    foreach (var comment in comments)
        //    {
        //        commentsCopy.Add(comment);
        //    }
        //    List<CommentDTO> result = new List<CommentDTO>();
        //    foreach (var comment in commentsCopy)
        //    {
        //        var commenter = _userFacade.GetAllUser().Result.Single(u => u.Id == comment.CommenterId);
        //        string commenterName = $"{commenter.Name}";
        //        result.Add(new CommentDTO(comment.Comment, comment.UserId, commenter.Id, $"{commenter.Name}"));
        //    }
        //    return result;
        //}

        //public IEnumerable<CommentDTO> GetProjectComments(int id)
        //{
        //    var comments = _evoNaploContext.ProjectComments.Where(c => c.CommenterId == id);
        //    List<ProjectComment> commentsCopy = new List<ProjectComment>();
        //    foreach (var comment in comments)
        //    {
        //        commentsCopy.Add(comment);
        //    }
        //    List<CommentDTO> result = new List<CommentDTO>();
        //    foreach (var comment in commentsCopy)
        //    {
        //        var commenter = _userFacade.GetAllUser().Result.FirstOrDefault(u => u.Id == comment.CommenterId);
        //        string commenterName = $"{commenter.Name}";
        //        result.Add(new CommentDTO(comment.Comment, comment.CommenterId, commenter.Id, $"{commenter.Name}"));
        //    }
        //    return result;
        //}
    }
}
