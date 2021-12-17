using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.UserDomain.Services
{
    public class AdminService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly ILogger<AdminService> _logger;

        public AdminService(ILogger<AdminService> logger, EvoNaploContext EvoNaploContext)
        {
            _logger = logger;
            _evoNaploContext = EvoNaploContext;
        }

        public async Task<IEnumerable<User>> AddAdminAsync(User user)
        {
            _logger.LogInformation($"Admin hozzáadása következik: {user}");
            user.Role = RoleType.Admin;
            await _evoNaploContext.Users.AddAsync(user);

            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"Admin hozzáadva.");
            var admins = _evoNaploContext.Users.Where(m => m.Role == RoleType.Admin);
            return admins.ToList();
        }

        public async Task<IEnumerable<UserDTO>> ListAdminsAsync()
        {
            IEnumerable<User> admins = _evoNaploContext.Users.Where(m => m.Role == RoleType.Admin).ToList();
            IEnumerable<UserDTO> userDTOs = admins.Select(x => new UserDTO(x, true));
            return userDTOs;
        }
    }
}