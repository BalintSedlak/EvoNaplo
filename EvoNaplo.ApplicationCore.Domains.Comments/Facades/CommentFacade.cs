using EvoNaplo.ApplicationCore.Domains.Comments.Services;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.TableConnectors;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.ApplicationCore.Domains.Comments.Facades
{
    public class CommentFacade : ICommentFacade
    {
        private readonly CommentService _commentService;
        private readonly ILogger _logger;

        public CommentFacade(CommentService commentService, ILogger logger)
        {
            _commentService = commentService;
            _logger = logger;
        }

        public IEnumerable<CommentDTO> GetStudentComments(int id)
        {

            throw new NotImplementedException();
        }

        public void AddStudentComment(StudentComment studentComment)
        {
            throw new NotImplementedException();
            _logger.LogInformation($"{studentComment.Id} student comment was created by {studentComment.UserId}");
        }

        public IEnumerable<CommentDTO> GetProjectComments(int id)
        {
            throw new NotImplementedException();
        }

        public void EditStudentComment(CommentDTO studentComment)
        {
            throw new NotImplementedException();
            _logger.LogInformation($"{studentComment.Id} student comment was edited by {studentComment.CommenterId}");
        }

        public void EditProjectComment(CommentDTO projectComment)
        {
            throw new NotImplementedException();
            _logger.LogInformation($"{projectComment.Id} project comment was edited by {projectComment.CommenterId}");
        }

        public void AddProjectComment(ProjectComment projectComment)
        {
            throw new NotImplementedException();
            _logger.LogInformation($"{projectComment.Id} project comment was created by {projectComment.CommenterId} on project: {projectComment.ProjectId}");
        }
    }
}
