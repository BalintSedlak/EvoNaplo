using EvoNaplo.Infrastructure.DomainFacades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentFacade _studentFacade;

        public StudentController(IStudentFacade studentFacade)
        {
            _studentFacade = studentFacade;
        }
    }
}
