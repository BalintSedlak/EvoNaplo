using EvoNaplo.Controllers;
using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
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
    class AttendanceSheetControllerTest
    {
        AttendanceSheetController _attendanceSheetController;
        EvoNaploContext _evoNaploContext;

        
        public void SetUp(string databaseName)
        {
            //TODO: Populate database
            _evoNaploContext = EvoNaploContextHelper.CreateInMemoryDatabaseContext(databaseName);
            AttendanceSheetService attendanceSheetService = new AttendanceSheetService(_evoNaploContext);

            _attendanceSheetController = new AttendanceSheetController(attendanceSheetService);
        }

        [TearDown]
        public void TearDown()
        {
            _attendanceSheetController = null;
        }

        [Test]
        public async Task GetAttendanceSheets_with_2_data()
        {
            //Arrange
            SetUp(nameof(GetAttendanceSheets_with_2_data));
            await FillAtendanceSheet();

            //Act
            IEnumerable<AttendanceSheetDTO> actualSheets = _attendanceSheetController.GetAttendanceSheets();

            //Assert
            Assert.AreEqual(2, actualSheets.Count());

        }
        [Test]
        public async Task AddAttendanceSheet_ValidData()
        {
            //Arrange
            SetUp(nameof(AddAttendanceSheet_ValidData));
            int expectedNumberOfAttendanceSheets = _evoNaploContext.AttendanceSheets.ToList().Count() + 1;
            AttendanceSheet attendanceSheet = new()
            {
                Id = 3,
                MeetingDate = new DateTime(2021, 6, 4),
                ProjectId = 1
            };

            //Act
            await _attendanceSheetController.PostAddAttendanceSheet(attendanceSheet);

            //Assert
            int actualNumberOfAttendanceSheets = _evoNaploContext.AttendanceSheets.ToList().Count();
            Assert.AreEqual(expectedNumberOfAttendanceSheets, actualNumberOfAttendanceSheets);
            Assert.True(_evoNaploContext.AttendanceSheets.Last() == attendanceSheet);

        }
        [Test]
        public async Task EditAttendanceSheet()
        {
            //Arrange
            SetUp(nameof(EditAttendanceSheet));
            await FillAtendanceSheet();

            AttendanceSheet testSheet = new();

            testSheet.Id = 1;
            testSheet.ProjectId = 1;
            DateTime testDate = testSheet.MeetingDate;
            testSheet.MeetingDate = new DateTime(2021, 9, 29);

            //Act
            await _attendanceSheetController.EditAttendanceSheet(testSheet);
            _evoNaploContext.SaveChanges();

            //Assert
            Assert.AreNotEqual(testDate, _evoNaploContext.AttendanceSheets.First(s => s.Id == testSheet.Id).MeetingDate);
        }
        [Test]
        public async Task DeleteAttendanceSheet()
        {
            //Arrange
            SetUp(nameof(DeleteAttendanceSheet));
            await FillAtendanceSheet();

            AttendanceSheet testSheet = _evoNaploContext.AttendanceSheets.First();
            int testid = testSheet.Id;

            //Act
            await _attendanceSheetController.DeleteAttendanceSheet(testSheet.Id);
            _evoNaploContext.SaveChanges();

            //Assert
            Assert.IsFalse(_evoNaploContext.AttendanceSheets.Select(s=>s.Id).ToList().Contains(testid));



        }
        public async Task FillAtendanceSheet()
        {
            //Arrange
            SetUp(nameof(FillAtendanceSheet));
            Semester semester = new()
            {
                Id = 1,
                StartDate = new DateTime(2016, 8, 21),
                EndDate = new DateTime(2022, 9, 13),
                IsAppliable = true
            };
            _evoNaploContext.Semesters.Add(semester);
            Project project = new()
            {
                Id = 1,
                ProjectName = "EvoNaplo",
                Description = "Egy naplo",
                SourceLink = "asd",
                Technologies = "C#",
                SemesterId = 1
            };
            _evoNaploContext.Projects.Add(project);

            List<AttendanceSheet> sheets = new();
            AttendanceSheet sheet1 = new()
            {
                Id = 1,
                MeetingDate = new DateTime(2021, 10, 14),
                ProjectId = 1

            };
            AttendanceSheet sheet2 = new()
            {
                Id = 2,
                MeetingDate = new DateTime(2021, 11, 24),
                ProjectId = 1
            };
            sheets.Add(sheet1);
            sheets.Add(sheet2);
            await _evoNaploContext.AttendanceSheets.AddRangeAsync(sheets);
            _evoNaploContext.SaveChanges();
        }
    }
}