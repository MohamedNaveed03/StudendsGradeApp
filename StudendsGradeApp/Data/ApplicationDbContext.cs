using Microsoft.EntityFrameworkCore;
using StudendsGradeApp.Models;

namespace StudendsGradeApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {   
        }

        public DbSet<Student> Students { get; set; }
    }

}
