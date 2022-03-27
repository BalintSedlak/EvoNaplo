using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.TestHelper;
using EvoNaplo.ApplicationCore.Domains.Users.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvoNaplo.ApplicationCore.Domains.Users.Services;
using EvoNaplo.ApplicationCore.Domains.Users.Facades;
using EvoNaplo.Infrastructure.Helpers;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DataAccess;

namespace EvoNaplo.ApplicationCore.Domains.Users.IntegrationTest
{
    [TestFixture]
    public class UserFacadeTest
    {
        private UserHelper _userHelper;

        private IUserFacade _userFacade;
        private EvoNaploContext _evoNaploContext;

        private int _OriginalNumberOfAdmins = 2;
        private int _OriginalNumberOfMentors = 3;
        private int _OriginalNumberOfStudents = 12;

        public void SetUp(string databaseName)
        {
            //SetUp database helpers
            _userHelper = new UserHelper();

            //Setup database
            _evoNaploContext = TestDbContextHelper
                .CreateInMemoryContext(databaseName)
                .CreateRepository<UserEntity>()
                    .CreateDefaultUsers(_OriginalNumberOfAdmins, RoleType.Admin)
                    .CreateDefaultUsers(_OriginalNumberOfMentors, RoleType.Mentor)
                    .CreateDefaultUsers(_OriginalNumberOfStudents, RoleType.Student)
                .Build();

            Mock<ILogger<AdminService>> mockAdminLogger = new Mock<ILogger<AdminService>>();
            Mock<ILogger<MentorService>> mockMentorLogger = new Mock<ILogger<MentorService>>();

            AdminService adminService = new AdminService(TestDbContextHelper.InjectRepository<UserEntity>(), _userHelper, mockAdminLogger.Object);
            MentorService mentorService = new MentorService(TestDbContextHelper.InjectRepository<UserEntity>(), _userHelper, mockMentorLogger.Object);
            StudentService studentService = new StudentService(TestDbContextHelper.InjectRepository<UserEntity>(), _userHelper);
            UserService userService = new UserService(TestDbContextHelper.InjectRepository<UserEntity>(), studentService, mentorService, adminService, _userHelper);
            _userFacade = new UserFacade(adminService, mentorService, studentService, userService);
        }

        [TearDown]
        public void TearDown()
        {
            _userFacade = null;
            _evoNaploContext = null;
        }

        [Test]
        public async Task AddUserAsync_AddValidAdmin_AdminUserIsSuccessfullyAddedToDatabase()
        {
            //Arrange
            SetUp(nameof(AddUserAsync_AddValidAdmin_AdminUserIsSuccessfullyAddedToDatabase));
            int expectedNumberOfAdmins = _OriginalNumberOfAdmins + 1;
            UserEntity newAdmin = UserGenerator.CreateDefaultUser(RoleType.Admin);
            UserViewModel newAdminViewModel = _userHelper.ConvertUserToUserViewModel(newAdmin);

            //Act
            await _userFacade.AddUserAsync(newAdminViewModel);

            //Assert
            int actualNumberOfAdmins = _evoNaploContext.Users.Count(x => x.Role == RoleType.Admin);
            Assert.AreEqual(expectedNumberOfAdmins, actualNumberOfAdmins);
        }

        [Test]
        public async Task AddUserAsync_AddValidMentor_MentorUserIsSuccessfullyAddedToDatabase()
        {
            //Arrange
            SetUp(nameof(AddUserAsync_AddValidMentor_MentorUserIsSuccessfullyAddedToDatabase));
            int expectedNumberOfMentors = _OriginalNumberOfMentors + 1;
            UserEntity newMentor = UserGenerator.CreateDefaultUser(RoleType.Mentor);
            UserViewModel newMentorViewModel = _userHelper.ConvertUserToUserViewModel(newMentor);

            //Act
            await _userFacade.AddUserAsync(newMentorViewModel);

            //Assert
            int actualNumberOfMentors = _evoNaploContext.Users.Count(x => x.Role == RoleType.Mentor);
            Assert.AreEqual(expectedNumberOfMentors, actualNumberOfMentors);
        }
        [Test]
        public async Task AddUserAsync_AddValidStudent_StudentUserIsSuccessfullyAddedToDatabase()
        {
            //Arrange
            SetUp(nameof(AddUserAsync_AddValidStudent_StudentUserIsSuccessfullyAddedToDatabase));
            int expectedNumberOfStudent = _OriginalNumberOfStudents + 1;
            UserEntity newStudent = UserGenerator.CreateDefaultUser(RoleType.Student);
            UserViewModel newStudentViewModel = _userHelper.ConvertUserToUserViewModel(newStudent);

            //Act
            await _userFacade.AddUserAsync(newStudentViewModel);

            //Assert
            int actualNumberOfStudents = _evoNaploContext.Users.Count(x => x.Role == RoleType.Student);
            Assert.AreEqual(expectedNumberOfStudent, actualNumberOfStudents);
        }

        [Test]
        public async Task GetAllUserFromRoleTypeAsync_AdminRoleType_ReturnsWithAllAdminUser()
        {
            //Arrange
            SetUp(nameof(GetAllUserFromRoleTypeAsync_AdminRoleType_ReturnsWithAllAdminUser));
            int expectedNumberOfAdmins = _OriginalNumberOfAdmins;

            //Act
            IEnumerable<UserDTO> actualNumberOfAdmins = await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Admin);

            //Assert
            Assert.AreEqual(expectedNumberOfAdmins, actualNumberOfAdmins.Count());
        }

        [Test]
        public async Task GetAllUserFromRoleTypeAsync_MentorRoleType_ReturnsWithAllMentorUser()
        {
            //Arrange
            SetUp(nameof(GetAllUserFromRoleTypeAsync_MentorRoleType_ReturnsWithAllMentorUser));
            int expectedNumberOfMentors = _OriginalNumberOfMentors;

            //Act
            IEnumerable<UserDTO> actualNumberOfMentors = await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Mentor);

            //Assert
            Assert.AreEqual(expectedNumberOfMentors, actualNumberOfMentors.Count());
        }
        [Test]
        public async Task GetAllUserFromRoleTypeAsync_StudentRoleType_ReturnsWithAllStudentUser()
        {
            //Arrange
            SetUp(nameof(GetAllUserFromRoleTypeAsync_StudentRoleType_ReturnsWithAllStudentUser));
            int expectedNumberOfStudents = _OriginalNumberOfStudents;

            //Act
            IEnumerable<UserDTO> actualNumberOfStudents = await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Student);

            //Assert
            Assert.AreEqual(expectedNumberOfStudents, actualNumberOfStudents.Count());
        }
        [Test]
        public async Task DeleteUserAsync_DeleteValidMentor_MentorSuccessfullyDeleted()
        {
            //Arrange
            SetUp(nameof(DeleteUserAsync_DeleteValidMentor_MentorSuccessfullyDeleted));
            int expectedNumberOfMentors = _OriginalNumberOfMentors;
            UserEntity newMentor = UserGenerator.CreateDefaultUser(RoleType.Mentor);
            _evoNaploContext.Users.Add(newMentor);
            _evoNaploContext.SaveChanges();

            //Act
            await _userFacade.DeleteUserAsync(newMentor.Id);
            int actualNumberOfMentors = _evoNaploContext.Users.Count(x => x.Role == RoleType.Mentor);

            //Assert
            Assert.AreEqual(expectedNumberOfMentors, actualNumberOfMentors);
        }
        [Test]
        public async Task DeleteUserAsync_DeleteValidAdmin_AdminSuccessfullyDeleted()
        {
            //Arrange
            SetUp(nameof(DeleteUserAsync_DeleteValidAdmin_AdminSuccessfullyDeleted));
            int expectedNumberOfAdmins = _OriginalNumberOfAdmins;
            UserEntity newAdmin = UserGenerator.CreateDefaultUser(RoleType.Admin);
            _evoNaploContext.Users.Add(newAdmin);
            _evoNaploContext.SaveChanges();

            //Act
            await _userFacade.DeleteUserAsync(newAdmin.Id);
            int actualNumberOfAdmins = _evoNaploContext.Users.Count(x => x.Role == RoleType.Admin);

            //Assert
            Assert.AreEqual(expectedNumberOfAdmins, actualNumberOfAdmins);
        }
        [Test]
        public async Task DeleteUserAsync_DeleteValidStudent_StudentSuccessfullyDeleted()
        {
            //Arrange
            SetUp(nameof(DeleteUserAsync_DeleteValidStudent_StudentSuccessfullyDeleted));
            int expectedNumberOfStudents = _OriginalNumberOfStudents;
            UserEntity newStudent = UserGenerator.CreateDefaultUser(RoleType.Student);
            _evoNaploContext.Users.Add(newStudent);
            _evoNaploContext.SaveChanges();

            //Act
            await _userFacade.DeleteUserAsync(newStudent.Id);
            int actualNumberOfStudents = _evoNaploContext.Users.Count(x => x.Role == RoleType.Student);

            //Assert
            Assert.AreEqual(expectedNumberOfStudents, actualNumberOfStudents);
        }
        [Test]
        public void GetUser_GetCreatedMentor_RegisteredInDB()
        {
            //Arrange
            SetUp(nameof(GetUser_GetCreatedMentor_RegisteredInDB));
            UserEntity newMentor = UserGenerator.CreateDefaultUser(RoleType.Mentor);
            _evoNaploContext.Users.Add(newMentor);
            _evoNaploContext.SaveChanges();
            int idOfNewMentor = newMentor.Id;


            //Act
            UserDTO newUser = _userFacade.GetUser(idOfNewMentor);

            //Assert
            Assert.IsTrue(newUser.Email==newMentor.Email);
            Assert.IsTrue(newUser.Id == newMentor.Id);
            Assert.IsTrue(newUser.PhoneNumber==newMentor.PhoneNumber);
            Assert.IsTrue(newUser.Role == newMentor.Role);
        }
        [Test]
        public void GetUser_GetCreatedAdmin_RegisteredInDB()
        {
            //Arrange
            SetUp(nameof(GetUser_GetCreatedAdmin_RegisteredInDB));
            UserEntity newAdmin = UserGenerator.CreateDefaultUser(RoleType.Admin);
            _evoNaploContext.Users.Add(newAdmin);
            _evoNaploContext.SaveChanges();
            int idOfNewAdmin = newAdmin.Id;


            //Act
            UserDTO newUser = _userFacade.GetUser(idOfNewAdmin);

            //Assert
            Assert.IsTrue(newUser.Email == newAdmin.Email);
            Assert.IsTrue(newUser.Id == newAdmin.Id);
            Assert.IsTrue(newUser.PhoneNumber == newAdmin.PhoneNumber);
            Assert.IsTrue(newUser.Role == newAdmin.Role);
        }
        [Test]
        public void GetUser_GetCreatedStudent_RegisteredInDB()
        {
            //Arrange
            SetUp(nameof(GetUser_GetCreatedStudent_RegisteredInDB));
            UserEntity newStudent = UserGenerator.CreateDefaultUser(RoleType.Student);
            _evoNaploContext.Users.Add(newStudent);
            _evoNaploContext.SaveChanges();
            int idOfNewStudent = newStudent.Id;


            //Act
            UserDTO newUser = _userFacade.GetUser(idOfNewStudent);

            //Assert
            Assert.IsTrue(newUser.Email == newStudent.Email);
            Assert.IsTrue(newUser.Id == newStudent.Id);
            Assert.IsTrue(newUser.PhoneNumber == newStudent.PhoneNumber);
            Assert.IsTrue(newUser.Role == newStudent.Role);
        }
        [Test]
        public async Task GetAllUser_GetAllRoleType_ReturnEveryRegisteredUser() 
        { 
            //Arrange
            SetUp(nameof(GetAllUser_GetAllRoleType_ReturnEveryRegisteredUser));
            int expectedNumberOfusers = _OriginalNumberOfStudents+_OriginalNumberOfAdmins+_OriginalNumberOfMentors;

            //Act
            IEnumerable<UserDTO> actualNumberOfUsers = await _userFacade.GetAllUser();

            //Assert
            Assert.AreEqual(expectedNumberOfusers, actualNumberOfUsers.Count());
        }
        [Test]
        public void GetUserById_GetCreatedMentor_RegisteredInDB()
        {
            //Arrange
            SetUp(nameof(GetUserById_GetCreatedMentor_RegisteredInDB));
            UserEntity newMentor = UserGenerator.CreateDefaultUser(RoleType.Mentor);
            _evoNaploContext.Users.Add(newMentor);
            _evoNaploContext.SaveChanges();
            int idOfNewMentor = newMentor.Id;


            //Act
            UserDTO newUser = _userFacade.GetUser(idOfNewMentor);

            //Assert
            Assert.IsTrue(newUser.Email == newMentor.Email);
            Assert.IsTrue(newUser.Id == newMentor.Id);
            Assert.IsTrue(newUser.PhoneNumber == newMentor.PhoneNumber);
            Assert.IsTrue(newUser.Role == newMentor.Role);
        }
        [Test]
        public void GetUserById_GetCreatedAdmin_RegisteredInDB()
        {
            //Arrange
            SetUp(nameof(GetUserById_GetCreatedAdmin_RegisteredInDB));
            UserEntity newAdmin = UserGenerator.CreateDefaultUser(RoleType.Admin);
            _evoNaploContext.Users.Add(newAdmin);
            _evoNaploContext.SaveChanges();
            int idOfNewAdmin = newAdmin.Id;


            //Act
            UserDTO newUser = _userFacade.GetUser(idOfNewAdmin);

            //Assert
            Assert.IsTrue(newUser.Email == newAdmin.Email);
            Assert.IsTrue(newUser.Id == newAdmin.Id);
            Assert.IsTrue(newUser.PhoneNumber == newAdmin.PhoneNumber);
            Assert.IsTrue(newUser.Role == newAdmin.Role);
        }
        [Test]
        public void GetUserById_GetCreatedStudent_RegisteredInDB()
        {
            //Arrange
            SetUp(nameof(GetUserById_GetCreatedStudent_RegisteredInDB));
            UserEntity newStudent = UserGenerator.CreateDefaultUser(RoleType.Student);
            _evoNaploContext.Users.Add(newStudent);
            _evoNaploContext.SaveChanges();
            int idOfNewStudent = newStudent.Id;


            //Act
            UserDTO newUser = _userFacade.GetUser(idOfNewStudent);

            //Assert
            Assert.IsTrue(newUser.Email == newStudent.Email);
            Assert.IsTrue(newUser.Id == newStudent.Id);
            Assert.IsTrue(newUser.PhoneNumber == newStudent.PhoneNumber);
            Assert.IsTrue(newUser.Role == newStudent.Role);
        }
        [Test]
        public void IsEmailExists_TestForNewUser()
        {
            //Arrange
            SetUp(nameof(IsEmailExists_TestForNewUser));
            UserEntity newStudent = UserGenerator.CreateDefaultUser(RoleType.Student);
            _evoNaploContext.Users.Add(newStudent);
            _evoNaploContext.SaveChanges();


            //Act
            bool isExists = _userFacade.IsEmailExists(newStudent.Email);

            //Assert
            Assert.True(isExists);
        }
        [Test]
        public async Task UpdateUserAsync_UpdatePropertiesOfAlreadyAddedUser()
        {
            //Arrange
            SetUp(nameof(UpdateUserAsync_UpdatePropertiesOfAlreadyAddedUser));
            UserEntity newStudent = UserGenerator.CreateDefaultUser(RoleType.Student);
            _evoNaploContext.Users.Add(newStudent);
            _evoNaploContext.SaveChanges();
            UserEntity copyStudent = newStudent;
            string newEmail = "Test email, written by tester";
            copyStudent.Email = newEmail;
            UserViewModel newCopyStudentViewModel = _userHelper.ConvertUserToUserViewModel(copyStudent);


            //Act
            await _userFacade.UpdateUserAsync(newCopyStudentViewModel);

            //Assert
            Assert.IsTrue(_evoNaploContext.Users.First(x=> x.Id==newStudent.Id).Email==newEmail);
        }
        [Test]
        public async Task SetUserRole_ChangeOriginalMentorToAdmin()
        {
            //Arrange
            SetUp(nameof(SetUserRole_ChangeOriginalMentorToAdmin));
            UserEntity firstMentor = _evoNaploContext.Users.First(x => x.Role == RoleType.Mentor);
            UserViewModel newMentorViewModel = _userHelper.ConvertUserToUserViewModel(firstMentor);
            //Act
            await _userFacade.SetUserRole(newMentorViewModel, RoleType.Admin);
            //Assert
            Assert.IsTrue(firstMentor.Role==RoleType.Admin);
            Assert.AreEqual(_evoNaploContext.Users.Count(x => x.Role == RoleType.Mentor), _OriginalNumberOfMentors - 1);
            Assert.AreEqual(_evoNaploContext.Users.Count(x => x.Role == RoleType.Admin), _OriginalNumberOfAdmins + 1);
        }
        [Test]
        public void GetUserByEmail_GetEmailOfOriginalAdmin()
        {
            //Arrange
            SetUp(nameof(GetUserByEmail_GetEmailOfOriginalAdmin));
            UserEntity firstAdmin = _evoNaploContext.Users.First(x => x.Role == RoleType.Admin);

            //Act
            UserAuth userAuth= _userFacade.GetUserByEmail(firstAdmin.Email);
            //Assert
            Assert.IsTrue(userAuth.Email == firstAdmin.Email);
            Assert.IsTrue(userAuth.Id==firstAdmin.Id);
        }

    }
}
