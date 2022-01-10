using EvoNaplo.Infrastructure.DataAccessLayer;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using Microsoft.Extensions.Logging;
using EvoNaplo.Infrastructure.Helpers;
using EvoNaplo.Infrastructure.DataAccess.Entities;

namespace EvoNaplo.ApplicationCore.Domains.Users.Services
{
    public class AdminService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly UserHelper _userHelper;
        private readonly ILogger<AdminService> _logger;

        public AdminService(IRepository<UserEntity> userRepository, UserHelper userHelper, ILogger<AdminService> logger)
        {
            _userRepository = userRepository;
            _userHelper = userHelper;
            _logger = logger;
        }

        //internal async Task<IEnumerable<User>> AddAdminAsync(UserViewModel user)
        //{
        //    _logger.LogInformation($"Admin hozzáadása következik: {user}");
        //    user.Role = RoleType.Admin;
        //    _userRepository.Add(_userHelper.ConvertUserViewModelToUser(user));

        //    _userRepository.SaveChangesAsync();
        //    _logger.LogInformation($"Admin hozzáadva.");
        //    var admins = _userRepository.GetAll().Where(m => m.Role == RoleType.Admin);
        //    return admins.ToList();
        //}

        internal async Task<IEnumerable<UserDTO>> ListAdminsAsync()
        {
            IEnumerable<UserEntity> admins = _userRepository.GetAll().Where(m => m.Role == RoleType.Admin).ToList();
            IEnumerable<UserDTO> userDTOs = admins.Select(x => _userHelper.ConvertUserToUserDTO(x));
            return userDTOs;
        }
    }
}