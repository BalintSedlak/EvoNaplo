using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Domains.Users.Models;

namespace EvoNaplo.Services
{
    public class SessionService
    {
        public SessionDTO GetSessionDTO(UserDTO user)
        {
            return new SessionDTO(user);
        }
    }
}
