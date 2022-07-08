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


        internal IEnumerable<UserDTO> ListStudents()
        {
            var students = _userRepository.GetAll().Where(m => m.Role == RoleType.Student);
            List<UserDTO> result = new List<UserDTO>();
            foreach (var student in students)
            {
                var userDTO = new UserDTO();
                userDTO.Email = student.Email;
                userDTO.Role = student.Role;
                userDTO.Name = student.FirstName + " " + student.LastName;
                userDTO.Id = student.Id;
                result.Add(userDTO);
            }

            return result;
        }

}
