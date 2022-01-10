using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Models.Entities;
using EvoNaplo.Domains.Users.Models;

namespace EvoNaplo.Common.DomainFacades
{
    public interface IUserFacade
    {
        Task AddUserAsync(UserViewModel user);
        UserDTO GetUser(int userId);
        Task<IQueryable<UserDTO>> GetAllUser();
        Task<IEnumerable<UserDTO>> GetAllUserFromRoleTypeAsync(RoleType roleType);
        UserDTO GetUserById(int userId);
        bool IsEmailExists(string email);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(UserViewModel user);
        Task SetUserRole(UserViewModel user, RoleType newRole);
        UserAuth GetUserByEmail(string email);
    }
}
