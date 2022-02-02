using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Exceptions;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.ApplicationCore.Domains.Auth.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.ApplicationCore.Domains.Auth.Facades
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IUserFacade _userFacade;
        private readonly AuthService _authService;
        private readonly ILogger _logger;

        public AuthFacade(IUserFacade userFacade, AuthService authService, ILogger logger)
        {
            _userFacade = userFacade;
            _authService = authService;
            _logger=logger;
        }

        public string Login(LoginViewModel loginDTO)
        {
            try
            {
                var value = _authService.Login(loginDTO);
                _logger.LogInformation($"User: {loginDTO.email} logged in");
                return value;
            }
            catch (ServiceException ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                    _logger.LogInformation($"User: {loginDTO.email} failed to log in");
                }
                throw;
            }
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
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                }
                throw new ServiceException(HttpStatusCode.Unauthorized, ex.Message);
            }

            return user;
        }

        public void RegisterNewUser(UserViewModel userViewModel)
        {
            try
            {
                userViewModel.Password = BCrypt.Net.BCrypt.HashPassword(userViewModel.Password);
                _userFacade.AddUserAsync(userViewModel);
                _logger.LogInformation($"{userViewModel.Email} has been registered");
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                    _logger.LogInformation($"Failed to register {userViewModel.Id} user");
                }
                throw;
            }
        }

        public SessionDTO GetSession(UserDTO user)
        {
            return _authService.GetSession(user);
        }
    }
}
