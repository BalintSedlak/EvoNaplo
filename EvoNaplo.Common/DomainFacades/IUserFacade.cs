using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;

namespace EvoNaplo.Common.DomainFacades
{
    public interface IUserFacade
    {
        //TODO
        //Task AddUserAsync(User user);
        Task<IEnumerable<UserDTO>> GetAllUserFromRoleTypeAsync(RoleType roleType);
        //Task<User> GetUser(int userId);
    }
}
