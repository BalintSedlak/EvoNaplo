using EvoNaplo.Infrastructure.DataAccessLayer;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.Infrastructure.Helpers;
using EvoNaplo.Infrastructure.DataAccess.Entities;

namespace EvoNaplo.ApplicationCore.Domains.Users.Services
{
    public class StudentService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly UserHelper _userHelper;

        public StudentService(IRepository<UserEntity> userRepository, UserHelper userHelper)
        {
            _userRepository = userRepository;
            _userHelper = userHelper;
        }

        internal bool EmailExists(string email)
        {
            if (_userRepository.GetAll().FirstOrDefault(u => u.Email == email) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //internal async Task AddStudentAsync(UserViewModel user)
        //{
        //    user.Role = RoleType.Student;
        //    user.Password = _authFacade.RegisterNewUser(user.Password);
        //    _userRepository.Add(_userHelper.ConvertUserViewModelToUser(user));
        //    await _userRepository.SaveChangesAsync();
        //}

        internal IEnumerable<UserDTO> ListStudents()
        {
            var students = _userRepository.GetAll().Where(m => m.Role == RoleType.Student);
            List<UserDTO> result = new List<UserDTO>();

            return result;
        }

        //public IEnumerable<UserDTO> ListStudents()
        //{
        //    var mostRecentSmesterId = _userRepository.Semesters.Max(semester => semester.Id);
        //    var UsersOnSemester = _userRepository.UsersOnSemester.Where(usersOnSemester => usersOnSemester.SemesterId == mostRecentSmesterId);
        //    var students = _userRepository.Users.Where(m => m.Role == RoleType.Student);
        //    List<UserDTO> result = new List<UserDTO>();
        //    foreach (var student in students)
        //    {
        //        if (UsersOnSemester.Any(usersOnSemester => usersOnSemester.UserId == student.Id))
        //        {
        //            result.Add(new UserDTO(student, true));
        //        }
        //        else
        //        {
        //            result.Add(new UserDTO(student, false));
        //        }
        //    }
        //    return result;
        //}

        //public async Task<IEnumerable<User>> EditStudent(int id, StudentDto studentDto)
        //{
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák keresése");
        //    var studentToEdit = await _evoNaploContext.Users.FindAsync(id);
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák módosítása indul {studentDto} adatokra");
        //    studentToEdit.Email = studentDto.Email;
        //    studentToEdit.SetNewPassword(studentDto.Password);
        //    studentToEdit.FirstName = studentDto.FirstName;
        //    studentToEdit.LastName = studentDto.LastName;
        //    studentToEdit.PhoneNumber = studentDto.PhoneNumber;
        //    _evoNaploContext.SaveChanges();
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák módosítása kész");
        //    var students = _evoNaploContext.Users.Where(m => m.Role == Role.Student);
        //    return students.ToList();
        //}

        //public async Task<IEnumerable<User>> InactivateStudent(int id)
        //{
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák keresése");
        //    var studentToDelete = await _evoNaploContext.Users.FindAsync(id);
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák inaktiválása indul");
        //    studentToDelete.IsActive = false;
        //    _evoNaploContext.SaveChanges();
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák inaktiválása kész");
        //    var students = _evoNaploContext.Users.Where(m => m.Role == Role.Student);
        //    return students.ToList();
        //}

        internal async Task<IEnumerable<UserEntity>> DeleteUser(int id)
        {
            var studentToDelete = _userRepository.GetAll().Single(x => x.Id == id);
            var role = studentToDelete.Role;
            _userRepository.Remove(studentToDelete);
            await _userRepository.SaveChangesAsync();
            var students = _userRepository.GetAll().Where(m => m.Role == role);
            return students.ToList();
        }
    }
}
