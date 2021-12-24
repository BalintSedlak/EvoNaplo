using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.UserDomain.Services;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.UserDomain.Models;
using System.IdentityModel.Tokens.Jwt;
using EvoNaplo.Common.Exceptions;
using System.Net;

namespace EvoNaplo.UserDomain.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly AdminService _adminService;
        private readonly MentorService _mentorService;
        private readonly StudentService _studentService;
        private readonly UserService _userService;
        private readonly AuthService _authService;

        public UserFacade(AdminService adminService, MentorService mentorService, StudentService studentService, UserService userService, AuthService authService)
        {
            _adminService = adminService;
            _mentorService = mentorService;
            _studentService = studentService;
            _userService = userService;
            _authService = authService;
        }

        public async Task AddUserAsync(UserViewModel user)
        {
            switch (user.Role)
            {
                case RoleType.Student:
                    await _studentService.AddStudentAsync(user);
                    break;
                case RoleType.Mentor:
                    await _mentorService.AddMentorAsync(user);
                    break;
                case RoleType.Admin:
                    await _adminService.AddAdminAsync(user);
                    break;
                default:
                    //TODO: Better logging
                    throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUserFromRoleTypeAsync(RoleType roleType)
        {
            switch (roleType)
            {
                case RoleType.Student:
                    return _studentService.ListStudents();
                    break;
                case RoleType.Mentor:
                    return await _mentorService.ListMentorsAsync();
                case RoleType.Admin:
                    return await _adminService.ListAdminsAsync();
                default:
                    //TODO: Better logging
                    throw new NotImplementedException();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
        }

        public UserDTO GetUser(int userId)
        {
            return _userService.GetUserById(userId);
        }

        public async Task<IQueryable<UserDTO>> GetAllUser()
        {
            List<UserDTO> result = new();

            result.AddRange(await this.GetAllUserFromRoleTypeAsync(RoleType.Admin));
            result.AddRange(await this.GetAllUserFromRoleTypeAsync(RoleType.Mentor));
            result.AddRange(await this.GetAllUserFromRoleTypeAsync(RoleType.Student));

            return result.AsQueryable<UserDTO>();
        }

        public UserDTO GetUserById(int userId)
        {
            return _userService.GetUserById(userId);
        }

        public bool IsEmailExists(string email)
        {
            //TODO: refactor this
            return _studentService.EmailExists(email);
        }

        public async Task UpdateUserAsync(UserViewModel user)
        {
            await _userService.EditUser(user);
        }

        public async Task SetUserRole(UserViewModel user, RoleType newRole)
        {
            await _userService.EditUserRole(user, newRole);
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
                user = _userService.GetUserById(userId);
            }
            //TODO: Use specific exception
            catch (Exception ex)
            {
                throw new ServiceException(HttpStatusCode.Unauthorized, ex.Message);
            }

            return user;
        }
    }
}
