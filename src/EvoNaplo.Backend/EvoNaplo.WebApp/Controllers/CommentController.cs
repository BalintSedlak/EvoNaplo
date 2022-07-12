using EvoNaplo.ApplicationCore.Domains.Comments.Facades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.TableConnectors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentFacade _commentFacade;

        public CommentController(CommentFacade commentFacade)
        {
            _commentFacade = commentFacade;
        }

        [HttpGet("StudentComments")]
        public IEnumerable<CommentDTO> GetStudentComments(int id)
        {
            return _commentFacade.GetStudentComments(id);
        }

        [HttpPost("StudentComment")]
        public IActionResult StudentComment([FromBody] StudentComment studentComment)
        {
            _commentFacade.AddStudentComment(studentComment);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("ProjectComments")]
        public IEnumerable<CommentDTO> GetProjectComments(int id)
        {
            return _commentFacade.GetProjectComments(id);
        }

        [HttpPost("ProjectComment")]
        public IActionResult ProjectComment([FromBody] ProjectComment projectComment)
        {
            _commentFacade.AddProjectComment(projectComment);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost("EditStudentComment")]
        public IActionResult EditStudentComment([FromBody] CommentDTO studentComment)
        {
            _commentFacade.EditStudentComment(studentComment);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost("EditProjectComment")]
        public IActionResult EditProjectComment([FromBody] CommentDTO projectComment)
        {
            _commentFacade.EditProjectComment(projectComment);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
