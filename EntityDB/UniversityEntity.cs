using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using trial_project_for_MVC_Core.Models;

namespace trial_project_for_MVC_Core.EntityDB
{
    public class UniversityEntity : IdentityDbContext<AppUser>
    {
        public UniversityEntity(DbContextOptions options):base(options)
        {

        }
        public DbSet<University> Universities { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        //public DbSet<College> Colleges { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Lab> Labs { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<subject> Subjects { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
    }
}
