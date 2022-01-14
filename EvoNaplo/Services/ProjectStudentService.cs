﻿using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.Models.DTO;
using EvoNaplo.Common.Models.TableConnectors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using EvoNaplo.Common.DomainFacades;

namespace EvoNaplo.Services
{
    public class ProjectStudentService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly IUserFacade _userFacade;

        public ProjectStudentService(EvoNaploContext EvoNaploContext, IUserFacade userFacade)
        {
            _evoNaploContext = EvoNaploContext;
            _userFacade = userFacade;
        }

        private List<int> GetUsersOnProjectIds(int projectId)
        {
            var userProjects = _evoNaploContext.UserProjects.Where(up => up.ProjectId == projectId).ToList();
            List<int> usersOnProjectIds = new List<int>();
            userProjects.ForEach(up =>
            {
                usersOnProjectIds.Add(up.UserId);
            });
            return usersOnProjectIds;
        }

        internal ProjectStudentsDTO GetProjectStudents()
        {
            if (_evoNaploContext.Semesters.ToList().Count == 0)
            {
                return new ProjectStudentsDTO();
            }
            var mostRecentSemesterId = _evoNaploContext.Semesters.Max(semester => semester.Id);
            var projects = _evoNaploContext.Projects.Where(project => project.SemesterId == mostRecentSemesterId).ToList();

            List<UserDTO> usersOnProject = new List<UserDTO>();
            foreach (var project in projects)
            {
                List<int> usersOnProjectIds = GetUsersOnProjectIds(project.Id);
                foreach (var userId in usersOnProjectIds)
                {
                    usersOnProject.Add(_userFacade.GetUserById(userId));
                }
            }
            
            var projectStudentTable = _evoNaploContext.UserProjects.ToList();

            ProjectStudentsDTO projectStudentsDTO = new ProjectStudentsDTO();

            projectStudentsDTO.usersOnProject = usersOnProject.Select(user => new ProjectUser(user)).ToList();
            //projectStudentsDTO.usersNotOnProject = usersNotOnProject.Select(user => new ProjectUser(user)).ToList();

            foreach (var project in projects)
            {
                ColumnProject columnProject = new ColumnProject(project);

                foreach (var projectStudent in projectStudentTable)
                {
                    if (projectStudent.ProjectId == project.Id)
                    {
                        columnProject.ProjectStudentIds.Add(projectStudent.UserId.ToString());
                    }
                }

                projectStudentsDTO.columnProjects.Add(columnProject);
                projectStudentsDTO.columnOrder.Add(columnProject.Id);
            }

            return projectStudentsDTO;
        }

        public bool ManageStudentOnProject(StudentToProjectDTO studentToProjectDTO)
        {
            try
            {
                var userProjecToEdit = _evoNaploContext.UserProjects.FirstOrDefault(u => u.UserId == studentToProjectDTO.studentId && u.ProjectId == studentToProjectDTO.fromProjectId);

                if (userProjecToEdit == null)
                {
                    return false;
                }
                userProjecToEdit.ProjectId = studentToProjectDTO.toProjectId;
                _evoNaploContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task JoinProjectAsStudent(int studentId, int projectId)
        {
            var newRowToAdd = new UserProject();
            newRowToAdd.UserId = studentId;
            newRowToAdd.ProjectId = projectId;
            await _evoNaploContext.UserProjects.AddAsync(newRowToAdd);
        }

        public async Task LeaveProjectAsStudent(int studentId, int projectId)
        {
            var rowToDelete = _evoNaploContext.UserProjects.First(row => row.UserId == studentId && row.ProjectId == projectId);
            _evoNaploContext.UserProjects.Remove(rowToDelete);
        }
    }
}
