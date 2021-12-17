using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.UserDomain.Services;
using EvoNaplo.Common.DomainFacades;

namespace EvoNaplo.UserDomain.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly AdminService _adminService;
        private readonly MentorService _mentorService;

        public UserFacade(AdminService adminService, MentorService mentorService)
        {
            _adminService = adminService;
            _mentorService = mentorService;
        }

        public async Task AddUserAsync(User user)
        {
            switch (user.Role)
            {
                case RoleType.Student:
                    //TODO: StudentService
                    throw new NotImplementedException();
                    //break;
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
                    //TODO: StudentService
                    throw new NotImplementedException();
                    //break;
                case RoleType.Mentor:
                    return await _mentorService.ListMentorsAsync();
                case RoleType.Admin:
                    return await _adminService.ListAdminsAsync();
                default:
                    //TODO: Better logging
                    throw new NotImplementedException();
            }
        }

        public Task<User> GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
