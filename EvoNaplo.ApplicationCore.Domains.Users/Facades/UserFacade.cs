using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.ApplicationCore.Domains.Users.Services;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.Models.Entities;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.ApplicationCore.Domains.Users.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly AdminService _adminService;
        private readonly MentorService _mentorService;
        private readonly StudentService _studentService;
        private readonly UserService _userService;
        private readonly ILogger _logger;

        public UserFacade(AdminService adminService, MentorService mentorService, StudentService studentService, UserService userService, ILogger logger)
        {
            _adminService = adminService;
            _mentorService = mentorService;
            _studentService = studentService;
            _userService = userService;
            _logger = logger;
        }

        public async Task AddUserAsync(UserViewModel user)
        {
            await _userService.AddNewStudentAsync(user);
            _logger.LogInformation($"{user.Id} user was added");

            //switch (user.Role)
            //{
                //case RoleType.Student:
                //    await _studentService.AddStudentAsync(user);
                //    break;
                //case RoleType.Mentor:
                //    await _mentorService.AddMentorAsync(user);
                //    break;
                //case RoleType.Admin:
                //    await _adminService.AddAdminAsync(user);
                //    break;
                //default:
                //    //TODO: Better logging
                //    throw new NotImplementedException();
            //}
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
            _logger.LogInformation($"{id} user was deleted");
        }

        public UserDTO GetUser(int userId)
        {
            return _userService.GetUserById(userId);
        }

        public async Task<IQueryable<UserDTO>> GetAllUser()
        {
            List<UserDTO> result = new();

            result.AddRange(await GetAllUserFromRoleTypeAsync(RoleType.Admin));
            result.AddRange(await GetAllUserFromRoleTypeAsync(RoleType.Mentor));
            result.AddRange(await GetAllUserFromRoleTypeAsync(RoleType.Student));

            return result.AsQueryable();
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
            _logger.LogInformation($"{user.Id} user was updated");
        }

        public async Task SetUserRole(UserViewModel user, RoleType newRole)
        {
            await _userService.EditUserRole(user, newRole);
            _logger.LogInformation($"{user.Id} user's role was changed to the following: {newRole}");
        }

        public UserAuth GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }
    }
}
