using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.Infrastructure.Helpers;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DataAccess;

namespace EvoNaplo.ApplicationCore.Domains.Users.Services
{
    public class StudentService
    {
        private readonly IRepository<StudentEntity> _studentRepository;
        private readonly UserHelper _userHelper;

        public StudentService(IRepository<StudentEntity> studentRepository, UserHelper userHelper)
        {
            _studentRepository = studentRepository;
            _userHelper = userHelper;
        }

        internal bool EmailExists(string email)
        {
            if (_studentRepository.GetAll().FirstOrDefault(u => u.Email == email) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal IEnumerable<StudentEntity> ListStudents()
        {
            return _studentRepository.GetAll();
        }

        internal StudentEntity GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        internal async Task<StudentEntity> UpdateStudent(StudentEntity updatedStudent)
        {
            _studentRepository.Update(updatedStudent);
            var student = _studentRepository.GetById(updatedStudent.Id);
            await _studentRepository.SaveChangesAsync();
            return student;
        }

        //internal async Task AddStudentAsync(UserViewModel user)
        //{
        //    user.Role = RoleType.Student;
        //    user.Password = _authFacade.RegisterNewUser(user.Password);
        //    _userRepository.Add(_userHelper.ConvertUserViewModelToUser(user));
        //    await _userRepository.SaveChangesAsync();
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

        //internal async Task<IEnumerable<UserEntity>> DeleteUser(int id)
        //{
        //    var studentToDelete = _userRepository.GetAll().Single(x => x.Id == id);
        //    var role = studentToDelete.Role;
        //    _userRepository.Remove(studentToDelete);
        //    await _userRepository.SaveChangesAsync();
        //    var students = _userRepository.GetAll().Where(m => m.Role == role);
        //    return students.ToList();
        //}
    }
}
