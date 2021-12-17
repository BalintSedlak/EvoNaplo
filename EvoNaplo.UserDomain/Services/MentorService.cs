using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using Microsoft.Extensions.Logging;

namespace EvoNaplo.UserDomain.Services
{
    public class MentorService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly ILogger<MentorService> _logger;

        public MentorService(ILogger<MentorService> logger, EvoNaploContext EvoNaploContext)
        {
            _logger = logger;
            _evoNaploContext = EvoNaploContext;
        }

        public async Task<IEnumerable<User>> AddMentorAsync(User user)
        {
            _logger.LogInformation($"Mentor hozzáadása következik: {user}");
            user.Role = RoleType.Mentor;
            await _evoNaploContext.Users.AddAsync(user);

            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"Mentor hozzáadva.");
            var mentors = _evoNaploContext.Users.Where(m => m.Role == RoleType.Mentor);
            return mentors.ToList();
        }

        public async Task<IEnumerable<UserDTO>> ListMentorsAsync()
        {
            IEnumerable<User> mentors = _evoNaploContext.Users.Where(m => m.Role == RoleType.Mentor);
            IEnumerable<UserDTO> userDTOs = mentors.Select(x => new UserDTO(x, true));
            return userDTOs;
        }
    }
}
