using EvoNaplo.Controllers;
using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using EvoNaplo.Models.TableConnectors;
using EvoNaplo.Services;
using EvoNaplo.TestHelper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNaplo.IntegrationTest
{
    [TestFixture]
    class StudentControllerTest
    {
        StudentController _studentController;
        EvoNaploContext _evoNaploContext;

        
        public void SetUp(string databaseName)
        {
            //TODO: Populate database
            _evoNaploContext = EvoNaploContextHelper.CreateInMemoryDatabaseContext(databaseName);
            StudentService studentService = new StudentService(_evoNaploContext);

            _studentController = new StudentController(studentService);
        }

        [TearDown]
        public void TearDown()
        {
            _studentController = null;
        }

        [Test]
        public async Task PostAddStudent()
        {
            //Arrange
            SetUp(nameof(PostAddStudent));
            List<User> users=_evoNaploContext.Users.Where(u => u.Role == Models.User.RoleTypes.Student).ToList();
            int expectedNumber = users.Count+1;

            //Act
            await _studentController.PostAddStudent(UserHelper.CreateDefaultUser(User.RoleTypes.Student));
            _evoNaploContext.SaveChanges();
            int actualNumber = _evoNaploContext.Users.Where(u => u.Role == Models.User.RoleTypes.Student).ToList().Count;


            //Assert
            Assert.AreEqual(expectedNumber, actualNumber);


        }
        [Test]
        public void EmailExists()
        {
            //Arrange
            SetUp(nameof(EmailExists));
            _evoNaploContext.Users.Add(UserHelper.CreateDefaultUser(User.RoleTypes.Student));
            _evoNaploContext.SaveChanges();
            bool expected = true;
            User user = _evoNaploContext.Users.Last();

            //Act
            bool actual = _studentController.EmailExists(user.Email);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void GetStudent()
        {
            //Arrange
            SetUp(nameof(GetStudent));
            Semester semester = new()
            {
                Id = 2,
                StartDate = new DateTime(2016, 8, 21),
                EndDate = new DateTime(2022, 9, 13),
                IsAppliable = true
            };
            _evoNaploContext.Semesters.Add(semester);
            _evoNaploContext.SaveChanges();

            _evoNaploContext.Users.Add(UserHelper.CreateDefaultUser(User.RoleTypes.Student));
            _evoNaploContext.SaveChanges();

            _evoNaploContext.UsersOnSemester.Add(new UsersOnSemester(_evoNaploContext.Users.Last().Id, 2));
            _evoNaploContext.SaveChanges();


            List<User> expected = _evoNaploContext.Users.Where(u => u.Role == User.RoleTypes.Student).ToList();


            //Act
            IEnumerable<UserDTO> actual = _studentController.GetStudent();

            //Assert
            Assert.AreEqual(expected.Count, actual.Count());

        }
        [Test]
        public async Task DeleteUser()
        {
            //Arrange
            SetUp(nameof(DeleteUser));
            User user = UserHelper.CreateDefaultUser(User.RoleTypes.Student);
            _evoNaploContext.Users.Add(user);
            _evoNaploContext.SaveChanges();

            //Act
            await _studentController.DeleteUser(user.Id);
            _evoNaploContext.SaveChanges();

            //Assert
            Assert.IsFalse(_evoNaploContext.Users.Where(u => u.Role == User.RoleTypes.Student).ToList().Contains(user));

        }
    }
}
