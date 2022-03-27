using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.TestHelper;
using NUnit.Framework;

namespace EvoNaplo.ApplicationCore.Domains.Auth.IntegrationTest
{
    public class AuthFacadeTest
    {

        private IUserFacade _userFacade;
        private EvoNaploContext _evoNaploContext;

        public void SetUp(string databaseName)
        {

            //Setup database
            _evoNaploContext = TestDbContextHelper
                .CreateInMemoryContext(databaseName)
                .CreateRepository<AuthEntity>()
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

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}