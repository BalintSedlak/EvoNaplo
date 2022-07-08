using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.ApplicationCore.Domains.Users.Services;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.Models.Entities;

namespace EvoNaplo.ApplicationCore.Domains.Users.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly AdminService _adminService;
        private readonly MentorService _mentorService;
        private readonly StudentService _studentService;
        private readonly UserService _userService;

        public UserFacade(AdminService adminService, MentorService mentorService, StudentService studentService, UserService userService)
        {
            _adminService = adminService;
            _mentorService = mentorService;
            _studentService = studentService;
            _userService = userService;
        }

        public async Task AddUserAsync(UserViewModel user)
        {
            await _userService.AddNewStudentAsync(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUserFromRoleTypeAsync(RoleType roleType)
        {
            switch (roleType)
            {
                //case RoleType.Student:
                //    return _studentService.ListStudents();
                //    break;
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

            result.AddRange(await GetAllUserFromRoleTypeAsync(RoleType.Admin));
            result.AddRange(await GetAllUserFromRoleTypeAsync(RoleType.Mentor));
            //result.AddRange(await GetAllUserFromRoleTypeAsync(RoleType.Student));

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
        }

        public async Task SetUserRole(UserViewModel user, RoleType newRole)
        {
            await _userService.EditUserRole(user, newRole);
        }

        public UserAuth GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }
    }
}
