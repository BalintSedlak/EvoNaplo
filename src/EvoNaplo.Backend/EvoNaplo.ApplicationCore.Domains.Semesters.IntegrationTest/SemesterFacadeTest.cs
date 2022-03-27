using EvoNaplo.ApplicationCore.Domains.Semesters.Facades;
using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.TestHelper;
using EvoNaplo.WebApp.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.ApplicationCore.Domains.Semesters.IntegrationTest
{
    public class SemesterFacadeTest
    {

        private ISemesterFacade _semesterFacade;
        private EvoNaploContext _evoNaploContext;


        public void SetUp(string databaseName)
        {

            //Setup database
            _evoNaploContext = TestDbContextHelper
                .CreateInMemoryContext(databaseName)
                .CreateRepository<SemesterEntity>()
                .Build();

            SemesterService semesterService = new SemesterService(TestDbContextHelper.InjectRepository<SemesterEntity>());
            _semesterFacade = new SemesterFacade(semesterService);
        }

        [TearDown]
        public void TearDown()
        {
            _semesterFacade = null;
            _evoNaploContext = null;
        }

        [Test]
        public void AddSemester_AddingAValidSemester_SuccessfullyAddedToDB()
        {
            //Arrange
            SetUp(nameof(AddSemester_AddingAValidSemester_SuccessfullyAddedToDB));
            SemesterEntity semesterEntity = new SemesterEntity();
            int expectedNumberOfSemesters = _evoNaploContext.Semesters.Count()+1;

            //Act
            _semesterFacade.AddSemester(semesterEntity);

            //Assert
            Assert.AreEqual(expectedNumberOfSemesters,_evoNaploContext.Semesters.Count());

        }
        [Test]
        public void GetSemesters_NumberOfSemesterAtStart_AddingASemester_CountShouldIncrease()
        {
            //Arrange
            SetUp(nameof(GetSemesters_NumberOfSemesterAtStart_AddingASemester_CountShouldIncrease));
            int expectedNumberOfSemesters = _evoNaploContext.Semesters.Count()+1;
            SemesterEntity semesterEntity=new SemesterEntity();
            _evoNaploContext.Semesters.Add(semesterEntity);
            _evoNaploContext.SaveChanges();

            //Act
            int actualNumberOfSemesters= _semesterFacade.GetSemesters().Count();

            //Assert
            Assert.AreEqual(expectedNumberOfSemesters,actualNumberOfSemesters);
        }
        [Test]
        public void GetSemesterById_CreateNewSemester_GetItFromDataBase()
        {
            //Arrange
            SetUp(nameof(GetSemesterById_CreateNewSemester_GetItFromDataBase));
            SemesterEntity semesterEntity = new SemesterEntity();
            semesterEntity.IsAppliable = true;
            semesterEntity.StartDate=DateTime.Now.AddDays(-2);
            _evoNaploContext.Semesters.Add(semesterEntity);
            _evoNaploContext.SaveChanges();

            //Act
            SemesterDTO semesterEntityActual = _semesterFacade.GetSemesterById(semesterEntity.Id);

            //Assert
            Assert.IsTrue(semesterEntity.StartDate == semesterEntityActual.StartDate);
        }
        [Test]
        public void GetSemesterToEditById_ExpectingSemeterEntityType()
        {
            //Arrange
            SetUp(nameof(GetSemesterToEditById_ExpectingSemeterEntityType));
            SemesterEntity semesterEntity = new SemesterEntity();
            semesterEntity.IsAppliable = true;
            semesterEntity.StartDate = DateTime.Now.AddDays(-2);
            _evoNaploContext.Semesters.Add(semesterEntity);
            _evoNaploContext.SaveChanges();

            //Act
            SemesterEntity semesterEntityActual = _semesterFacade.GetSemesterToEditById(semesterEntity.Id);

            //Assert
            Assert.IsTrue(semesterEntity.StartDate == semesterEntityActual.StartDate);
            Assert.IsTrue(semesterEntityActual.GetType() == typeof(SemesterEntity));
        }
        [Test]
        public void EditSemester_CreatingSemesterAddingToDataBase_EditAddedDatabase()
        {
            //Arrange
            SetUp(nameof(GetSemesterToEditById_ExpectingSemeterEntityType));
            SemesterEntity semesterEntity = new SemesterEntity();
            semesterEntity.IsAppliable = true;
            semesterEntity.StartDate = DateTime.Now.AddDays(-2);
            _evoNaploContext.Semesters.Add(semesterEntity);
            _evoNaploContext.SaveChanges();
            SemesterEntity semesterEntityCopy = new SemesterEntity(semesterEntity);
            semesterEntityCopy.StartDate = DateTime.Now.AddDays(-6);

            //Act
            _semesterFacade.EditSemester(semesterEntityCopy);

            //Assert
            Assert.IsTrue(semesterEntity.StartDate == semesterEntityCopy.StartDate);
        }
        [Test]
        public void DeleteSemester_DeletingASemesterFromDatabase_CheckingForNumbers()
        {
            //Arrange
            SetUp(nameof(DeleteSemester_DeletingASemesterFromDatabase_CheckingForNumbers));
            SemesterEntity semesterEntity= new SemesterEntity();
            _evoNaploContext.Semesters.Add(semesterEntity);
            _evoNaploContext.SaveChanges();
            int expectedNumberOfSemesters = _evoNaploContext.Semesters.Count() - 1;

            //Act
            _semesterFacade.DeleteSemester(semesterEntity.Id);

            //Assert
            Assert.AreEqual(expectedNumberOfSemesters, _evoNaploContext.Semesters.Count());

        }
    }
}