using EvoNaplo.Controllers;
using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using EvoNaplo.Models.TableConnectors;
using EvoNaplo.Services;
using EvoNaplo.TestHelper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNaplo.IntegrationTest
{
    [TestFixture]
    class MentorControllerTest
    {
        MentorController _mentorController;
        EvoNaploContext _evoNaploContext;

        
        public void SetUp(string databaseName)
        {
            //TODO: Populate database
            _evoNaploContext = EvoNaploContextHelper.CreateInMemoryDatabaseContext(databaseName);
            Mock<ILogger<MentorService>> mockLogger = new Mock<ILogger<MentorService>>();
            MentorService mentorService = new MentorService(mockLogger.Object, _evoNaploContext);

            _mentorController = new MentorController(mentorService);
        }

        [TearDown]
        public void TearDown()
        {
            _mentorController = null;
        }

        [Test]
        public async Task PostAddMentor_AddValid_Successful()
        {
            //Arrange
            SetUp(nameof(PostAddMentor_AddValid_Successful));
            int expectedNumberOfMentors = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Mentor).Count() + 1;
            User newMentor = UserHelper.CreateDefaultUser(User.RoleTypes.Mentor);

            //Act
            await _mentorController.PostAddMentor(newMentor);


            //Assert
            int actualNumberOfMentors = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Mentor).Count();
            Assert.AreEqual(expectedNumberOfMentors, actualNumberOfMentors);
            Assert.True(_evoNaploContext.Users.Last() == newMentor);

        }
        [Test]
        public void GetMentor()
        {
            //Arrange 
            SetUp(nameof(GetMentor));
            Semester semester = new()
            {
                Id = 2,
                StartDate = new DateTime(2016, 8, 21),
                EndDate = new DateTime(2022, 9, 13),
                IsAppliable = true
            };
            _evoNaploContext.Semesters.Add(semester);
            _evoNaploContext.SaveChanges();


            _evoNaploContext.Users.Add(UserHelper.CreateDefaultUser(User.RoleTypes.Mentor));
            _evoNaploContext.SaveChanges();

            _evoNaploContext.UsersOnSemester.Add(new UsersOnSemester(_evoNaploContext.Users.Last().Id, 2));
            _evoNaploContext.SaveChanges();


            //Act
            IEnumerable<UserDTO> mentors = _mentorController.GetMentor();


            _evoNaploContext.Users.Add(UserHelper.CreateDefaultUser(User.RoleTypes.Mentor));
            _evoNaploContext.SaveChanges();
            _evoNaploContext.UsersOnSemester.Add(new(_evoNaploContext.Users.Last().Id, 2));
            _evoNaploContext.SaveChanges();
            IEnumerable<UserDTO> mentors2 = _mentorController.GetMentor();


            //Assert
            Assert.AreEqual(mentors.Count() + 1, mentors2.Count());
        }



    }
}
