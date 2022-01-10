using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.ApplicationCore.Domains.Users.Models;

namespace EvoNaplo.WebApp.Services
{
    public class SessionService
    {
        public SessionDTO GetSessionDTO(UserDTO user)
        {
            return new SessionDTO(user);
        }
    }
}
