using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.UserDomain.Models;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.UserDomain.Services
{
    public class MentorService
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserHelper _userHelper;
        private readonly ILogger<MentorService> _logger;

        public MentorService(IRepository<User> userRepository, UserHelper userHelper, ILogger<MentorService> logger)
        {
            _userRepository = userRepository;
            _userHelper = userHelper;
            _logger = logger;
        }

        internal async Task<IEnumerable<User>> AddMentorAsync(UserViewModel user)
        {
            _logger.LogInformation($"Mentor hozzáadása következik: {user}");
            user.Role = RoleType.Mentor;
            _userRepository.Add(_userHelper.ConvertUserViewModelToUser(user));

            await _userRepository.SaveChangesAsync();
            _logger.LogInformation($"Mentor hozzáadva.");
            var mentors = _userRepository.GetAll().Where(m => m.Role == RoleType.Mentor);
            return mentors.ToList();
        }

        internal async Task<IEnumerable<UserDTO>> ListMentorsAsync()
        {
            IEnumerable<User> mentors = _userRepository.GetAll().Where(m => m.Role == RoleType.Mentor);
            IEnumerable<UserDTO> userDTOs = mentors.Select(x => _userHelper.ConvertUserToUserDTO(x));
            return userDTOs;
        }
    }
}
