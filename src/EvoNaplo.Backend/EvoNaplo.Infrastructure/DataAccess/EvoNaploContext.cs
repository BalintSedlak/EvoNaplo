using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.Infrastructure.Models.TableConnectors;
using Microsoft.EntityFrameworkCore;

namespace EvoNaplo.Infrastructure.DataAccess
{
    public class EvoNaploContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<AttendanceSheet> AttendanceSheets { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<SemesterEntity> Semesters { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<StudentComment> StudentComments { get; set; }
        public DbSet<StudentProject> StudentProjects { get; set; }
        public DbSet<MentorProject> MentorProjects { get; set; }
        public DbSet<StudentsOnSemester> StudentsOnSemester { get; set; }

        public EvoNaploContext(DbContextOptions<EvoNaploContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("EvoNaploContext");
            base.OnModelCreating(modelBuilder);
        }
    }
}
