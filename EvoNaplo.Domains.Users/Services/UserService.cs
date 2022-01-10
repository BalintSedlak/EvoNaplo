using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Models.Entities;
using EvoNaplo.Domains.Users.Models;

namespace EvoNaplo.Domains.Users.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly StudentService _studentService;
        private readonly MentorService _mentorService;
        private readonly AdminService _adminService;
        private readonly UserHelper _userHelper;

        public UserService(IRepository<User> userRepository, StudentService studentService, MentorService mentorService, AdminService adminService, UserHelper userHelper)
        {
            _userRepository = userRepository;
            _studentService = studentService;
            _mentorService = mentorService;
            _adminService = adminService;
            _userHelper = userHelper;
        }

        internal async Task EditUserRole(UserViewModel user, RoleType newRole)
        {
            var UserToEdit = _userRepository.GetById(user.Id);
            UserToEdit.Role = newRole;
            await _userRepository.SaveChangesAsync();
        }
        internal UserDTO GetUserById(int id)
        {
            return _userHelper.ConvertUserToUserDTO(_userRepository.GetById(id));
        }

        internal User GetUserToEditById(int id)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return new User(user);
            }
            else
            {
                return new User();
            }
        }

        internal UserAuth GetUserByEmail(string email)
        {
            var user = _userRepository.GetAll().Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                return new UserAuth(user);
            }
            return null;
        }

        internal async Task<IEnumerable<User>> EditUser(UserViewModel user)
        {
            var UserToEdit = _userRepository.GetAll().Single(x => x.Id == user.Id);
            UserToEdit.Email = user.Email;
            UserToEdit.FirstName = user.FirstName;
            UserToEdit.LastName = user.LastName;
            UserToEdit.PhoneNumber = user.PhoneNumber;
            UserToEdit.Password = user.Password;
            await _userRepository.SaveChangesAsync();
            var Users = _userRepository.GetAll().Where(m => m.Role == UserToEdit.Role);
            return Users.ToList();
        }

        internal async Task<IEnumerable<User>> DeleteUserAsync(int id)
        {
            var studentToDelete = _userRepository.GetAll().Single(x => x.Id == id);
            var role = studentToDelete.Role;
            _userRepository.Remove(studentToDelete);
            await _userRepository.SaveChangesAsync();
            var students = _userRepository.GetAll().Where(m => m.Role == role);
            return students.ToList();
        }

        internal int GetRoleByUserId(int id)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                return (int)user.Role;
            }
            else
            {
                return -1;
            }
        }
    }
}
