using Microsoft.EntityFrameworkCore;

namespace StudieJobsFinderMyDatabase.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Job { get; set; }

        // Andre DbSets kan tilføjes her
    }
}



