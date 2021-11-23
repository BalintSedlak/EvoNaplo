using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Services
{
    public class SessionService
    {
        public SessionDTO GetSessionDTO(User user)
        {
            return new SessionDTO(user);
        }
    }
}
