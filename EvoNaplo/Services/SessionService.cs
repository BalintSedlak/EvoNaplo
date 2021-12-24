using EvoNaplo.Common.Models.DTO;
using EvoNaplo.UserDomain.Models;

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
