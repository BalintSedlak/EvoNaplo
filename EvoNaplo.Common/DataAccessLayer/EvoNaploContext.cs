using EvoNaplo.Common.Models;
using EvoNaplo.Common.Models.TableConnectors;
using Microsoft.EntityFrameworkCore;

namespace EvoNaplo.Common.DataAccessLayer
{
    public class EvoNaploContext : DbContext
    {
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("EvoNaploContext");
            base.OnModelCreating(modelBuilder);
        }
    }
}
