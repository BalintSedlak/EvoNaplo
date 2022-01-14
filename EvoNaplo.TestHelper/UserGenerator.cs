using System;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.DataAccess.Entities;

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

        public static UserEntity CreateDefaultUser(RoleType userType)
        {
            UserEntity user;

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

        private static UserEntity CreateStudent()
        {
            return new UserEntity
            {
                FirstName = "New",
                LastName = $"Student{_studentCounter++}",
                Email = "new.student@company.com",
                PhoneNumber = "+36101234567",
                Password = "Password123456",
                Role = RoleType.Student
            };
        }

        private static UserEntity CreateMentor()
        {
            return new UserEntity
            {
                FirstName = "New",
                LastName = $"Mentor{_mentorCounter++}",
                Email = "new.mentor@company.com",
                PhoneNumber = "+36101234567",
                Password = "Password123456",
                Role = RoleType.Mentor
            };
        }

        private static UserEntity CreateAdmin()
        {
            return new UserEntity
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
