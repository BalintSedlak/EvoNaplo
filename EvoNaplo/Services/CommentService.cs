using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models.DTO;
using EvoNaplo.Models.TableConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.Services
{
    public class CommentService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly ILogger<AttendanceSheetService> _logger;

        public CommentService(ILogger<AdminService> logger,EvoNaploContext EvoNaploContext)
        {
            _logger = logger;
            _evoNaploContext = EvoNaploContext;
        }

        internal async Task AddStudentComment(StudentComment studentComment)
        {
            _logger.LogInformation($"{studentComment} hozzaadasa kovetkezik.")
            await _evoNaploContext.StudentComments.AddAsync(studentComment);
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"StudentComment hozzaadasa megtortent.")
        }

        internal async Task AddProjectComment(ProjectComment projectComment)
        {
            _logger.LogInformation($"{projectComment} hozzaadasa kovetkezik.")
            await _evoNaploContext.ProjectComments.AddAsync(projectComment);
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"ProjectComment hozzaadasa megtortent.")
        }

        internal async Task EditStudentComment(CommentDTO studentComment)
        {
            _logger.LogInformation($"{studentComment} modositasa kovetkezik.")
            var studentCommentToEdit = await _evoNaploContext.StudentComments.FindAsync(studentComment.Id);
            studentCommentToEdit.Comment = studentComment.Comment;
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"StudentComment modositasa megtortent.")
        }

        internal async Task EditProjectComment(CommentDTO projectComment)
        {
            _logger.LogInformation($"{projectComment} modositasa kovetkezik.")
            var projectCommentToEdit = await _evoNaploContext.ProjectComments.FindAsync(projectComment.Id);
            projectCommentToEdit.Comment = projectComment.Comment;
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"ProjectComment modositasa megtortent.")
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
                var commenter = _evoNaploContext.Users.FirstOrDefault(u => u.Id == comment.CommenterId);
                string commenterName = $"{commenter.FirstName} {commenter.LastName}";
                result.Add(new CommentDTO(comment.Comment, comment.UserId,commenter.Id,$"{commenter.FirstName} {commenter.LastName}" ));
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
                var commenter = _evoNaploContext.Users.FirstOrDefault(u => u.Id == comment.CommenterId);
                string commenterName = $"{commenter.FirstName} {commenter.LastName}";
                result.Add(new CommentDTO(comment.Comment, comment.CommenterId, commenter.Id, $"{commenter.FirstName} {commenter.LastName}"));
            }
            return result;
        }
    }
}
