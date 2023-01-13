using Microsoft.EntityFrameworkCore;
using MVCFastTactsoft.Models;

namespace MVCFastTactsoft.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext):base(dbContext)
        {

        }
        public DbSet<Registration> Registrations { get; set; }
    }
}
