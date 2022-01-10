using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Models.Entities;
using EvoNaplo.Domains.Users.Models;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.Domains.Users.Services
{
    public class AdminService
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserHelper _userHelper;
        private readonly ILogger<AdminService> _logger;

        public AdminService(IRepository<User> userRepository, UserHelper userHelper, ILogger<AdminService> logger)
        {
            _userRepository = userRepository;
            _userHelper = userHelper;
            _logger = logger;
        }

        internal async Task<IEnumerable<User>> AddAdminAsync(UserViewModel user)
        {
            _logger.LogInformation($"Admin hozzáadása következik: {user}");
            user.Role = RoleType.Admin;
            _userRepository.Add(_userHelper.ConvertUserViewModelToUser(user));

            _userRepository.SaveChangesAsync();
            _logger.LogInformation($"Admin hozzáadva.");
            var admins = _userRepository.GetAll().Where(m => m.Role == RoleType.Admin);
            return admins.ToList();
        }

        internal async Task<IEnumerable<UserDTO>> ListAdminsAsync()
        {
            IEnumerable<User> admins = _userRepository.GetAll().Where(m => m.Role == RoleType.Admin).ToList();
            IEnumerable<UserDTO> userDTOs = admins.Select(x => _userHelper.ConvertUserToUserDTO(x));
            return userDTOs;
        }
    }
}