using EvoNaplo.DataAccessLayer;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Services
{
    public class StudentService
    {
        private readonly EvoNaploContext _evoNaploContext;

        public StudentService(EvoNaploContext EvoNaploContext)
        {
            _evoNaploContext = EvoNaploContext;
        }
        
        public async Task<IEnumerable<User>> AddStudent(User user)
        {
            user.Role = User.RoleTypes.Student;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _evoNaploContext.Users.AddAsync(user);
            _evoNaploContext.SaveChanges();
            var students = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Student);
            return students.ToList();
        }

        public bool EmailExists(string email)
        {
            if(_evoNaploContext.Users.FirstOrDefault(u => u.Email == email) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<UserDTO> ListStudents()
        {
            var mostRecentSmesterId = _evoNaploContext.Semesters.Max(semester => semester.Id);
            var UsersOnSemester = _evoNaploContext.UsersOnSemester.Where(usersOnSemester => usersOnSemester.SemesterId == mostRecentSmesterId);
            var students = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Student);
            List<UserDTO> result = new List<UserDTO>();
            foreach (var student in students)
            {
                if (UsersOnSemester.Any(usersOnSemester => usersOnSemester.UserId == student.Id))
                {
                    result.Add(new UserDTO(student, true));
                }
                else
                {
                    result.Add(new UserDTO(student, false));
                }
            }
            return result;
        }

        public IEnumerable<UserDTO> ListJanis()
        {
            var mostRecentSmesterId = _evoNaploContext.Semesters.Max(semester => semester.Id);
            var UsersOnSemester = _evoNaploContext.UsersOnSemester.Where(usersOnSemester => usersOnSemester.SemesterId == mostRecentSmesterId);
            var janis = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Jani);
            List<UserDTO> result = new List<UserDTO>();
            foreach (var jani in janis)
            {
                if (UsersOnSemester.Any(usersOnSemester => usersOnSemester.UserId == jani.Id))
                {
                    result.Add(new UserDTO(jani, true));
                }
                else
                {
                    result.Add(new UserDTO(jani, false));
                }
            }
            return result;
        }

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

        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            var studentToDelete = await _evoNaploContext.Users.FindAsync(id);
            var role = studentToDelete.Role;
            _evoNaploContext.Users.Remove(studentToDelete);
            _evoNaploContext.SaveChanges();
            var students = _evoNaploContext.Users.Where(m => m.Role == role);
            return students.ToList();
        }
    }
}
