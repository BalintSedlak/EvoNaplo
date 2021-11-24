using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.Services
{
    public class SessionService
    {
        public SessionDTO GetSessionDTO(User user)
        {
            return new SessionDTO(user);
        }
    }
}
