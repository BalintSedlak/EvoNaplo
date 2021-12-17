using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using System.Linq;

namespace EvoNaplo.Services
{
    public class LoginService
    {
        private readonly EvoNaploContext _evoNaploContext;

        public LoginService(EvoNaploContext EvoNaploContext)
        {
            _evoNaploContext = EvoNaploContext;
        }

        public User LogInUser(LoginDTO loginDTO)
        {
            //Fetch the stored password
            User user = _evoNaploContext.Users.FirstOrDefault(u => u.Email == loginDTO.email);
            if(user == null)
            {
                return null;
            }
            return user;
        }

        public void LogOutUser()
        {
        }
    }
}
