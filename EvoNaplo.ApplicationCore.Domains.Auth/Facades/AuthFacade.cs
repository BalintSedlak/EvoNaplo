using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Exceptions;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.ApplicationCore.Domains.Auth.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using EvoNaplo.ApplicationCore.Domains.Users.Models;

namespace EvoNaplo.ApplicationCore.Domains.Auth.Facades
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

        public void RegisterNewUser(UserViewModel userViewModel)
        {
            userViewModel.Password = BCrypt.Net.BCrypt.HashPassword(userViewModel.Password);
            _userFacade.AddUserAsync(userViewModel);
        }
    }
}
