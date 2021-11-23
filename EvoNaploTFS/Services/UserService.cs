using EvoNaplo.DataAccessLayer;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using EvoNaploTFS.Models.TableConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Services
{
    public class UserService
    {
        private readonly EvoNaploContext _evoNaploContext;
        public UserService(EvoNaploContext EvoNaploContext)
        {
            _evoNaploContext = EvoNaploContext;
        }
        public IEnumerable<UserDTO> ListStudents()
        {
            if (_evoNaploContext.Semesters.ToList().Count == 0)
                return new List<UserDTO>();
            var mostRecentSmesterId = _evoNaploContext.Semesters.Max(semester => semester.Id);
            var UsersOnSemester = _evoNaploContext.UsersOnSemester.Where(usersOnSemester => usersOnSemester.SemesterId == mostRecentSmesterId).ToList();
            var students = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Student).ToList();
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
        public IEnumerable<UserDTO> ListActiveMentors()
        {
            if (_evoNaploContext.Semesters.ToList().Count == 0)
                return new List<UserDTO>();
            var mostRecentSmesterId = _evoNaploContext.Semesters.Max(semester => semester.Id);
            var UsersOnSemester = _evoNaploContext.UsersOnSemester.Where(usersOnSemester => usersOnSemester.SemesterId == mostRecentSmesterId).ToList();
            var mentors = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Mentor).ToList();
            List<UserDTO> result = new List<UserDTO>();
            foreach (var mentor in mentors)
            {
                if (UsersOnSemester.Any(usersOnSemester => usersOnSemester.UserId == mentor.Id))
                {
                    result.Add(new UserDTO(mentor, true));
                }
                else
                {
                    result.Add(new UserDTO(mentor, false));
                }
            }
            return result;
        }

        internal async Task EditUserRole(User user, User.RoleTypes newRole)
        {
                var UserToEdit = await _evoNaploContext.Users.FindAsync(user.Id);
                UserToEdit.Role = newRole;
                _evoNaploContext.SaveChanges();
        }

        public IEnumerable<UserDTO> ListActiveAdmins()
        {
            if (_evoNaploContext.Semesters.ToList().Count == 0)
                return new List<UserDTO>();
            var mostRecentSmesterId = _evoNaploContext.Semesters.Max(semester => semester.Id);
            var UsersOnSemester = _evoNaploContext.UsersOnSemester.Where(usersOnSemester => usersOnSemester.SemesterId == mostRecentSmesterId).ToList();
            var admins = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Admin).ToList();
            List<UserDTO> result = new List<UserDTO>();
            foreach (var admin in admins)
            {
                if (UsersOnSemester.Any(usersOnSemester => usersOnSemester.UserId == admin.Id))
                {
                    result.Add(new UserDTO(admin, true));
                }
                else
                {
                    result.Add(new UserDTO(admin, false));
                }
            }
            return result;
        }

        public UserDTO GetUserById(int id)
        {
            int mostRecentSmesterId = -1;
            List<UsersOnSemester> UsersOnSemester = new List<UsersOnSemester>();
            if (_evoNaploContext.Semesters.ToList().Count > 0)
            {
                mostRecentSmesterId = _evoNaploContext.Semesters.Max(semester => semester.Id);
                UsersOnSemester = _evoNaploContext.UsersOnSemester.Where(usersOnSemester => usersOnSemester.SemesterId == mostRecentSmesterId).ToList();
            }
            
            var user = _evoNaploContext.Users.FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
                if (UsersOnSemester.Any(usersOnSemester => usersOnSemester.UserId == user.Id))
                {
                    return new UserDTO(user, true);
                }
                else
                {
                    return new UserDTO(user, false);
                }
            }
            else
            {
                return new UserDTO();
            }
        }
        public User GetUserToEditById(int id)
        {
            var user = _evoNaploContext.Users.FirstOrDefault(u => u.Id == id);
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
            var UserToEdit = await _evoNaploContext.Users.FindAsync(user.Id);
            UserToEdit.Email = user.Email;
            UserToEdit.FirstName = user.FirstName;
            UserToEdit.LastName = user.LastName;
            UserToEdit.PhoneNumber = user.PhoneNumber;
            UserToEdit.Password = user.Password;
            _evoNaploContext.SaveChanges();
            var Users = _evoNaploContext.Users.Where(m => m.Role == UserToEdit.Role);
            return Users.ToList();
        }

        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            var studentToDelete = await _evoNaploContext.Users.FindAsync(id);
            var role = studentToDelete.Role;
            _evoNaploContext.Users.Remove(studentToDelete);
            _evoNaploContext.SaveChanges();
            var students = _evoNaploContext.Users.Where(m => m.Role == role);
            return students.ToList();
        }

        public int GetRoleByUserId(int id)
        {
            var user = _evoNaploContext.Users.FirstOrDefault(u => u.Id == id);

            if(user != null)
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
