using System;
using EvoNaplo.Common.Models.Entities;
using EvoNaplo.UserDomain.Models;

namespace EvoNaplo.TestHelper
{
    public static class UserGenerator
    {
        private static int _studentCounter;
        private static int _mentorCounter;
        private static int _adminCounter;

        static UserGenerator()
        {
            _studentCounter = 0;
            _mentorCounter = 0;
            _adminCounter = 0;
        }

        public static User CreateDefaultUser(RoleType userType)
        {
            User user;

            switch (userType)
            {
                case RoleType.Student:
                    user = CreateStudent();
                    break;
                case RoleType.Mentor:
                    user = CreateMentor();
                    break;
                case RoleType.Admin:
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
                LastName = $"Student{_studentCounter++}",
                Email = "new.student@company.com",
                PhoneNumber = "+36101234567",
                Password = "Password123456",
                Role = RoleType.Student
            };
        }

        private static User CreateMentor()
        {
            return new User
            {
                FirstName = "New",
                LastName = $"Mentor{_mentorCounter++}",
                Email = "new.mentor@company.com",
                PhoneNumber = "+36101234567",
                Password = "Password123456",
                Role = RoleType.Mentor
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
                Role = RoleType.Admin
            };
        }
    }
}
