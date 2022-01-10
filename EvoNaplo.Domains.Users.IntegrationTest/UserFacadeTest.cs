using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Models.Entities;
using EvoNaplo.TestHelper;
using EvoNaplo.Domains.Users.Facades;
using EvoNaplo.Domains.Users.Models;
using EvoNaplo.Domains.Users.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvoNaplo.AuthDomain.Facades;

namespace EvoNaplo.IntegrationTest
{
    [TestFixture]
    public class UserFacadeTest
    {
        private UserHelper _userHelper;

        private IUserFacade _userFacade;
        private EvoNaploContext _evoNaploContext;

        private int _OriginalNumberOfAdmins = 2;
        private int _OriginalNumberOfMentors = 3;
        private int _OriginalNumberOfStudent = 12;

        public void SetUp(string databaseName)
        {
            //SetUp database helpers
            _userHelper = new UserHelper();

            //Setup database
            _evoNaploContext = TestDbContextHelper
                .CreateInMemoryContext(databaseName)
                .CreateRepository<User>()
                    .CreateDefaultUsers(_OriginalNumberOfAdmins, RoleType.Admin)
                    .CreateDefaultUsers(_OriginalNumberOfMentors, RoleType.Mentor)
                    .CreateDefaultUsers(_OriginalNumberOfStudent, RoleType.Student)
                .Build();

            Mock<ILogger<AdminService>> mockAdminLogger = new Mock<ILogger<AdminService>>();
            Mock<ILogger<MentorService>> mockMentorLogger = new Mock<ILogger<MentorService>>();
            Mock<IAuthFacade> mockAuthFacade = new Mock<IAuthFacade>(); 

            AdminService adminService = new AdminService(TestDbContextHelper.InjectRepository<User>(), _userHelper, mockAdminLogger.Object);
            MentorService mentorService = new MentorService(TestDbContextHelper.InjectRepository<User>(), _userHelper, mockMentorLogger.Object);
            StudentService studentService = new StudentService(TestDbContextHelper.InjectRepository<User>(), mockAuthFacade.Object, _userHelper);
            UserService userService = new UserService(TestDbContextHelper.InjectRepository<User>(), studentService, mentorService, adminService, _userHelper);
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
            User newAdmin = UserGenerator.CreateDefaultUser(RoleType.Admin);
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
            User newMentor = UserGenerator.CreateDefaultUser(RoleType.Mentor);
            UserViewModel newMentorViewModel = _userHelper.ConvertUserToUserViewModel(newMentor);

            //Act
            await _userFacade.AddUserAsync(newMentorViewModel);

            //Assert
            int actualNumberOfMentors = _evoNaploContext.Users.Count(x => x.Role == RoleType.Mentor);
            Assert.AreEqual(expectedNumberOfMentors, actualNumberOfMentors);
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
    }
}
