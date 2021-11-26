using EvoNaplo.Controllers;
using EvoNaplo.Models;
using EvoNaplo.Services;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using EvoNaplo.DataAccessLayer;
using System.Linq;
using EvoNaplo.TestHelper;
using System.Threading.Tasks;

namespace EvoNaplo.IntegrationTest
{
    [TestFixture]
    public class AdminControllerTest
    {
        private AdminController _adminController;
        private EvoNaploContext _evoNaploContext;

        private int _OriginalNumberOfAdmins = 2;
        private int _OriginalNumberOfMentors = 3;
        private int _OriginalNumberOfStudent = 12;

        public void SetUp(string databaseName)
        {
            _evoNaploContext = EvoNaploContextHelper
                .CreateInMemoryDatabaseContext(databaseName)
                .CreateDefaultUsers(_OriginalNumberOfAdmins, User.RoleTypes.Admin)
                .CreateDefaultUsers(_OriginalNumberOfMentors, User.RoleTypes.Mentor)
                .CreateDefaultUsers(_OriginalNumberOfStudent, User.RoleTypes.Student);

            Mock<ILogger<AdminService>> mockLogger = new Mock<ILogger<AdminService>>();
            AdminService adminService = new AdminService(mockLogger.Object, _evoNaploContext);

            _adminController = new AdminController(adminService);
        }

        [TearDown]
        public void TearDown()
        {
            _adminController = null;
            _evoNaploContext = null;
        }

        [Test]
        public async Task PostAddAdmin_AddValidUser_Successful()
        {
            //Arrange
            SetUp(nameof(PostAddAdmin_AddValidUser_Successful));
            int expectedNumberOfAdmins = _OriginalNumberOfAdmins + _OriginalNumberOfMentors + _OriginalNumberOfStudent + 1;
            User newUser = UserHelper.CreateDefaultUser(User.RoleTypes.Admin);

            //Act
            await _adminController.PostAddAdmin(newUser);

            //Assert
            int actualNumberOfAdmins = _evoNaploContext.Users.Count();
            Assert.AreEqual(expectedNumberOfAdmins, actualNumberOfAdmins);
        }
    }
}
