using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Exceptions;
using EvoNaplo.Common.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace EvoNaplo.Domains.Auth.Services
{
    public class AuthService
    {
        //TODO: Move to config?
        private readonly string secureKey = "valami nagyonszupereroscucclikey";

        private readonly IUserFacade _userFacade;

        public AuthService(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        internal string Login(LoginViewModel loginViewModel)
        {
            UserAuth user = _userFacade.GetUserByEmail(loginViewModel.email);

            if (user == null)
            {
                throw new ServiceException(HttpStatusCode.BadRequest, "No such user");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginViewModel.password, user.Password))
            {
                throw new ServiceException(HttpStatusCode.BadRequest, "Bad password");
            }

            string jwt = GenerateToken(user.Id);

            return jwt;
        }


        internal string GenerateToken(int id)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        internal JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secureKey);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}
