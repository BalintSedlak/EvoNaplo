using EvoNaplo.Common.Models.DTO;

namespace EvoNaplo.AuthDomain.Facades
{
    public interface IAuthFacade
    {
        string Login(LoginViewModel loginDTO);
        UserDTO GetUserByJwt(string jwt);
        string HashPassword(string password);
    }
}