using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.Models.DTO;

namespace EvoNaplo.Infrastructure.DomainFacades
{
    public interface IAuthFacade
    {
        string Login(LoginViewModel loginDTO);
        UserDTO GetUserByJwt(string jwt);
        void RegisterNewUser(UserViewModel userViewModel);
        SessionDTO GetSession(UserDTO user);
    }
}