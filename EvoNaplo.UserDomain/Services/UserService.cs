using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Models.TableConnectors;
using EvoNaplo.UserDomain.Models;

namespace EvoNaplo.UserDomain.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly StudentService _studentService;
        private readonly MentorService _mentorService;
        private readonly AdminService _adminService;

        public UserService(IRepository<User> userRepository, StudentService studentService, MentorService mentorService, AdminService adminService)
        {
            _userRepository = userRepository;
            _studentService = studentService;
            _mentorService = mentorService;
            _adminService = adminService;
        }

        internal async Task EditUserRole(User user, RoleType newRole)
        {
            var UserToEdit = _userRepository.GetById(user.Id);
            UserToEdit.Role = newRole;
            await _userRepository.SaveChangesAsync();
        }
        public UserDTO GetUserById(int id)
        {
            return UserHelper.ConvertUserToUserDTO(_userRepository.GetById(id));
        }

        public User GetUserToEditById(int id)
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

        public async Task<IEnumerable<User>> EditUser(User user)
        {
            var UserToEdit = await _userRepository.GetAll().Single(user.Id);
            UserToEdit.Email = user.Email;
            UserToEdit.FirstName = user.FirstName;
            UserToEdit.LastName = user.LastName;
            UserToEdit.PhoneNumber = user.PhoneNumber;
            UserToEdit.Password = user.Password;
            await _userRepository.SaveChangesAsync();
            var Users = _userRepository.GetAll().Where(m => m.Role == UserToEdit.Role);
            return Users.ToList();
        }

        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            var studentToDelete = await _userRepository.GetAll().Single(id);
            var role = studentToDelete.Role;
            _userRepository.Remove(studentToDelete);
            await _userRepository.SaveChangesAsync();
            var students = _userRepository.GetAll().Where(m => m.Role == role);
            return students.ToList();
        }

        public int GetRoleByUserId(int id)
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
