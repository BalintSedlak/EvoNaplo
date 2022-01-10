using EvoNaplo.AuthDomain.Facades;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Exceptions;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Domains.Auth.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace EvoNaplo.Domains.Auth.Facades
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IUserFacade _userFacade;
        private readonly AuthService _authService;

        public AuthFacade(IUserFacade userFacade, AuthService authService)
        {
            _userFacade = userFacade;
            _authService = authService;
        }
        
        public string Login(LoginViewModel loginDTO)
        {
            return _authService.Login(loginDTO);
        }

        public UserDTO GetUserByJwt(string jwt)
        {
            UserDTO user;

            try
            {
                JwtSecurityToken token = _authService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                user = _userFacade.GetUserById(userId);
            }
            //TODO: Use specific exception
            catch (Exception ex)
            {
                throw new ServiceException(HttpStatusCode.Unauthorized, ex.Message);
            }

            return user;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
