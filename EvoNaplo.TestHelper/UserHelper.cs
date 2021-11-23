using System;
using EvoNaploTFS.Models;

namespace EvoNaplo.TestHelper
{
    public static class UserHelper
    {
        private static int _adminStudent;
        private static int _adminMentor;
        private static int _adminCounter;

        static UserHelper()
        {
            _adminStudent = 0;
            _adminMentor = 0;
            _adminCounter = 0;
        }

        public static User CreateDefaultUser(User.RoleTypes userType)
        {
            User user;

            switch (userType)
            {
                case User.RoleTypes.Student:
                    user = CreateStudent();
                    break;
                case User.RoleTypes.Mentor:
                    user = CreateMentor();
                    break;
                case User.RoleTypes.Admin:
                    user = CreateAdmin();
                    break;
                default:
                    throw new ArgumentException("Unimplemented RoleType.", nameof(userType));
            }

            return user;
        }

        private static User CreateStudent()
        {
            return new User
            {
                FirstName = "New",
                LastName = $"Admin{_adminStudent++}",
                Email = "new.admin@company.com",
                PhoneNumber = "+36101234567",
                Password = "Password123456",
                Role = User.RoleTypes.Student
            };
        }

        private static User CreateMentor()
        {
            return new User
            {
                FirstName = "New",
                LastName = $"Admin{_adminMentor++}",
                Email = "new.admin@company.com",
                PhoneNumber = "+36101234567",
                Password = "Password123456",
                Role = User.RoleTypes.Mentor
            };
        }

        private static User CreateAdmin()
        {
            return new User
            {
                FirstName = "Admin",
                LastName = $"Admin{_adminCounter++}",
                Email = "new.admin@company.com",
                PhoneNumber = "+36101234567",
                Password = "Password123456",
                Role = User.RoleTypes.Admin
            };
        }
    }
}
