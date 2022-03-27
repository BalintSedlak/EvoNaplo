using EvoNaplo.ApplicationCore.Domains.Projects.Facades;
using EvoNaplo.ApplicationCore.Domains.Projects.Services;
using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.TestHelper;
using NUnit.Framework;
using System.Linq;

namespace EvoNaplo.ApplicationCore.Domains.Projects.IntegrationTest
{
    public class ProjectFacadeTest
    {
        private IProjectFacade _projectFacade;
        private EvoNaploContext _evoNaploContext;

        public void SetUp(string databaseName)
        {

            //Setup database
            _evoNaploContext = TestDbContextHelper
                .CreateInMemoryContext(databaseName)
                .CreateRepository<ProjectEntity>()
                .Build();

            ProjectService projectService = new ProjectService(TestDbContextHelper.InjectRepository<ProjectEntity>());
            _projectFacade = new ProjectFacade(projectService);
        }

        [TearDown]
        public void TearDown()
        {
            _projectFacade = null;
            _evoNaploContext = null;
        }
        [Test]
        public void AddProject_AddingAValidProjectToDatabase()
        {
            //Arrange
            SetUp(nameof(AddProject_AddingAValidProjectToDatabase));
            int expectedNumberOfProjects = _evoNaploContext.Projects.Count()+1;

            ProjectEntity projectEntity=new ProjectEntity();

            //Act
            _projectFacade.AddProject(projectEntity);

            //Assert
            Assert.AreEqual(expectedNumberOfProjects, _evoNaploContext.Projects.Count());
        }
        [Test]
        public void DeleteProject_AddingAValidProjectToDatabase_RemoveTheAddedProject()
        {
            //Arrange
            SetUp(nameof(DeleteProject_AddingAValidProjectToDatabase_RemoveTheAddedProject));
            ProjectEntity projectEntity = new ProjectEntity();
            _evoNaploContext.Projects.Add(projectEntity);
            _evoNaploContext.SaveChanges();

            int expectedNumberOfProjects = _evoNaploContext.Projects.Count() - 1;

            //Act
            _projectFacade.DeleteProject(projectEntity.Id);

            //Assert
            Assert.AreEqual(expectedNumberOfProjects, _evoNaploContext.Projects.Count());
        }
        [Test]
        public void EditProject_CreateProjectToAddToDataBase_EditAddedDatabase()
        {
            //Arrange
            SetUp(nameof(EditProject_CreateProjectToAddToDataBase_EditAddedDatabase));
            ProjectEntity projectEntity= new ProjectEntity();
            _evoNaploContext.Projects.Add(projectEntity);
            _evoNaploContext.SaveChanges();
            ProjectEntity projectEntityCopy = new ProjectEntity(projectEntity);
            projectEntityCopy.Technologies = "Alma";

            //Act
            _projectFacade.EditProject(projectEntityCopy);

            //Assert
            Assert.IsTrue(projectEntity.Technologies==projectEntityCopy.Technologies);
        }
        [Test]
        public void GetProjectById_CreateProectAddToDataBase_GetTheAddedProject()
        {
            //Arrange
            SetUp(nameof(GetProjectById_CreateProectAddToDataBase_GetTheAddedProject));
            ProjectEntity projectEntity = new ProjectEntity();
            projectEntity.Technologies = "Kukac";
            _evoNaploContext.Projects.Add(projectEntity);
            _evoNaploContext.SaveChanges();

            //Act
            ProjectDTO projectEntityCopy = _projectFacade.GetProjectById(projectEntity.Id);

            //Assert
            Assert.IsTrue(projectEntity.Technologies == projectEntityCopy.Technologies);
        }
        [Test]
        public void GetProjects_GettingTheNumberOfRegisteredProjects()
        {
            //Arrange
            SetUp(nameof(GetProjects_GettingTheNumberOfRegisteredProjects));
            int expectedNumberOfProjects=_evoNaploContext.Projects.Count()+1;
            ProjectEntity projectEntity = new ProjectEntity();
            _evoNaploContext.Projects.Add(projectEntity);
            _evoNaploContext.SaveChanges();

            //Act
            int actualNumberOfProjects= _projectFacade.GetProjects().Count();

            //Assert
            Assert.AreEqual(expectedNumberOfProjects, actualNumberOfProjects);
        }
        [Test]
        public void GetProjectToEditById_CreateProectAddToDataBase_GetTheAddedProject_WatchReturnType()
        {
            //Arrange
            SetUp(nameof(GetProjectToEditById_CreateProectAddToDataBase_GetTheAddedProject_WatchReturnType));
            ProjectEntity projectEntity = new ProjectEntity();
            projectEntity.Technologies = "Kukac";
            _evoNaploContext.Projects.Add(projectEntity);
            _evoNaploContext.SaveChanges();

            //Act
            ProjectEntity projectEntityActual = _projectFacade.GetProjectToEditById(projectEntity.Id);

            //Assert
            Assert.IsTrue(projectEntity.Technologies == projectEntityActual.Technologies);
            Assert.IsTrue(projectEntityActual.GetType() == typeof(ProjectEntity));
        }

    }
}