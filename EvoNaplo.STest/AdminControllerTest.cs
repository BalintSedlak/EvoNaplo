using EvoNaploTFS.Controllers;
using EvoNaploTFS.Models;
using EvoNaploTFS.Services;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EvoNaplo.DataAccessLayer;
using System.Linq;
using EvoNaplo.TestHelper;
using System.Threading.Tasks;

namespace EvoNaplo.STest
{
    [TestFixture]
    public class AdminControllerTest
    {
        AdminController _adminController;
        EvoNaploContext _evoNaploContext;

        [SetUp]
        public void SetUp()
        {
            //TODO: Populate database
            _evoNaploContext = EvoNaploContextHelper.CreateInMemoryDatabaseContext();
            Mock<ILogger<AdminService>> mockLogger = new Mock<ILogger<AdminService>>();
            AdminService adminService = new AdminService(mockLogger.Object, _evoNaploContext);

            _adminController = new AdminController(adminService);
        }

        [TearDown]
        public void TearDown()
        {
            _adminController = null;
        }

        [Test]
        public async Task PostAddAdmin_AddValidUser_SuccessfulAsync()
        {
            //Arrange
            int expectedNumberOfAdmins = _evoNaploContext.Users.Count() + 1;
            User newUser = UserHelper.CreateDefaultUser(User.RoleTypes.Admin);

            //Act
            await _adminController.PostAddAdmin(newUser);

            //Assert
            int actualNumberOfAdmins = _evoNaploContext.Users.Count();
            Assert.AreEqual(expectedNumberOfAdmins, actualNumberOfAdmins);
        }

        
    }
}
