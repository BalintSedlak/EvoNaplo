using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.UserDomain.Models;

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
        string Login(LoginViewModel loginDTO);
        UserDTO GetUserByJwt(string jwt);
    }
}
