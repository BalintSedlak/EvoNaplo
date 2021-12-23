using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.UserDomain.Models;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.UserDomain.Services
{
    public class AdminService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ILogger<AdminService> _logger;

        public AdminService(ILogger<AdminService> logger, IRepository<User> userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> AddAdminAsync(User user)
        {
            _logger.LogInformation($"Admin hozzáadása következik: {user}");
            user.Role = RoleType.Admin;
            _userRepository.Add(user);

            _userRepository.SaveChangesAsync();
            _logger.LogInformation($"Admin hozzáadva.");
            var admins = _userRepository.GetAll().Where(m => m.Role == RoleType.Admin);
            return admins.ToList();
        }

        public async Task<IEnumerable<UserDTO>> ListAdminsAsync()
        {
            IEnumerable<User> admins = _userRepository.GetAll().Where(m => m.Role == RoleType.Admin).ToList();
            IEnumerable<UserDTO> userDTOs = admins.Select(x => UserHelper.ConvertUserToUserDTO(x));
            return userDTOs;
        }
    }
}