using GradingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GradingApp.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Professors> Professors { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Secretaries> Secretaries { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseHasStudents> CourseHasStudents { get; set; }
    }
}
