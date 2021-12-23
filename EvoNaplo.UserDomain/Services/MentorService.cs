using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.UserDomain.Models;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.UserDomain.Services
{
    public class MentorService
    {
        private readonly ILogger<MentorService> _logger;
        private readonly IRepository<User> _userRepository;

        public MentorService(ILogger<MentorService> logger, IRepository<User> userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> AddMentorAsync(User user)
        {
            _logger.LogInformation($"Mentor hozzáadása következik: {user}");
            user.Role = RoleType.Mentor;
            _userRepository.Add(user);

            await _userRepository.SaveChangesAsync();
            _logger.LogInformation($"Mentor hozzáadva.");
            var mentors = _userRepository.GetAll().Where(m => m.Role == RoleType.Mentor);
            return mentors.ToList();
        }

        public async Task<IEnumerable<UserDTO>> ListMentorsAsync()
        {
            IEnumerable<User> mentors = _userRepository.GetAll().Where(m => m.Role == RoleType.Mentor);
            IEnumerable<UserDTO> userDTOs = mentors.Select(x => UserHelper.ConvertUserToUserDTO(x));
            return userDTOs;
        }
    }
}
