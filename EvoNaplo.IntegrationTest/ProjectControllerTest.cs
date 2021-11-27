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
    class ProjectControllerTest
    {
        ProjectController _projectController;
        EvoNaploContext _evoNaploContext;

        
        public void SetUp(string databaseName)
        {
            //TODO: Populate database
            _evoNaploContext = EvoNaploContextHelper.CreateInMemoryDatabaseContext(databaseName);
            ProjectService projectService = new ProjectService( _evoNaploContext);

            _projectController = new ProjectController(projectService);
        }

        [TearDown]
        public void TearDown()
        {
            _projectController = null;
            _evoNaploContext = null;
        }
        [Test]
        public void GetProjects()
        {
            //Arrange
            SetUp(nameof(GetProjects));
            int expected = _evoNaploContext.Projects.Count() + 1;
            GetSampleProject(true);

            //Act
            int actual = _projectController.GetProjects().Count();

            //Assert
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public async Task PostAddProject()
        {
            //Arrange
            SetUp(nameof(PostAddProject));
            int expected = _evoNaploContext.Projects.Count() + 1;
            Project project = GetSampleProject(false);

            //Act   
            await _projectController.PostAddProject(project);
            _evoNaploContext.SaveChanges();

            //Assert
            Assert.AreEqual(expected, _evoNaploContext.Projects.Count());
        }
        [Test]
        public void GetProjectsOfCurrentSemester()
        {
            //Arrange
            SetUp(nameof(GetProjectsOfCurrentSemester));
            GetSampleProject(false);
            int expected=_evoNaploContext.Projects.Where(p => p.SemesterId == _evoNaploContext.Semesters.Max(s => s.Id)).ToList().Count();

            //Act
            int actual=_projectController.GetProjectsOfCurrentSemester().Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetProjectById()
        {
            //Arrange
            SetUp(nameof(GetProjectById));
            Project project=GetSampleProject(true);
            //ACt 
            ProjectDTO actual=_projectController.GetProjectById(project.Id);

            //Assert
            Assert.AreEqual(project.Id, actual.Id);
            Assert.AreEqual(project.ProjectName, actual.ProjectName);
            Assert.AreEqual(project.SemesterId, actual.SemesterId);
            Assert.AreEqual(project.SourceLink, actual.SourceLink);
            Assert.AreEqual(project.Technologies, actual.Technologies);
        }
        [Test]
        public void GetProjectToEditById()
        {
            //Arrange
            SetUp(nameof(GetProjectToEditById));
            Project project = GetSampleProject(true);
            //ACt 
            Project actual = _projectController.GetProjectToEditById(project.Id);

            //Assert
            Assert.AreEqual(project.Id, actual.Id);
            Assert.AreEqual(project.ProjectName, actual.ProjectName);
            Assert.AreEqual(project.SemesterId, actual.SemesterId);
            Assert.AreEqual(project.SourceLink, actual.SourceLink);
            Assert.AreEqual(project.Technologies, actual.Technologies);
        }
        [Test]
        public async Task EditProject()
        {
            //Arrange
            SetUp(nameof(EditProject));
            Project project = GetSampleProject(true);

            
            Project project1 = new(project);
            project1.ProjectName = "Test";
            project1.Technologies = "C#, JS";
            //Act
            await _projectController.EditProject(project1);
            _evoNaploContext.SaveChanges();
            //Assert
            Assert.IsTrue(_evoNaploContext.Projects.First().ProjectName == "Test");

        }
        [Test]
        public async Task DeleteProject()
        {
            //Assert
            SetUp(nameof(DeleteProject));
            Project project=GetSampleProject(true);
            //Act
            await _projectController.DeleteProject(project.Id);
            _evoNaploContext.SaveChanges();

            //Assert
            Assert.IsFalse(_evoNaploContext.Projects.Contains(project));
        }
        [Test]
        public void GetMyProjectThisSemester()
        {
            //Arrange
            SetUp(nameof(GetMyProjectThisSemester));
            ProjectDTO projectDTO=new(GetSampleProject(true));
            User user = UserHelper.CreateDefaultUser(User.RoleTypes.Student);
            _evoNaploContext.Users.Add(user);
            _evoNaploContext.UserProjects.Add(new UserProject(user.Id, 1));
            _evoNaploContext.SaveChanges();

            //Act
            ProjectDTO project =_projectController.GetMyProjectThisSemester(user.Id);

            //Assert
            Assert.IsTrue(projectDTO.Id == project.Id);
            Assert.IsTrue(projectDTO.ProjectName == project.ProjectName);


        }




        private Project GetSampleProject(bool add)
        {
            Semester semester = new()
            {
                Id = 1,
                IsAppliable = true,
                StartDate = new DateTime(2019, 9, 13),
                EndDate = new DateTime(2022, 5, 31)
            };
            _evoNaploContext.Semesters.Add(semester);
            _evoNaploContext.SaveChanges();
            Project project = new()
            {
                Id = 1,
                Description = "Evo napplo, egy naplo",
                ProjectName = "EvoNaplo",
                SemesterId = 1,
                Technologies = "C#",
                SourceLink = ""
            };
            if (add == true)
            {
                _evoNaploContext.Projects.Add(project);
                _evoNaploContext.SaveChanges();
            }
            return project;
        }



    }
}
