using EvoNaploTFS.Models;
using EvoNaploTFS.Models.TableConnectors;
using Microsoft.EntityFrameworkCore;

namespace EvoNaplo.DataAccessLayer
{
    public class EvoNaploContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AttendanceSheet> AttendanceSheets { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<StudentComment> StudentComments { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UsersOnSemester> UsersOnSemester { get; set; }

        public EvoNaploContext(DbContextOptions<EvoNaploContext> options) : base(options)
        {
        }
    }
}
