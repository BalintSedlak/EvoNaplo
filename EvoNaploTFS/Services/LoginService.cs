using EvoNaplo.DataAccessLayer;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

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
