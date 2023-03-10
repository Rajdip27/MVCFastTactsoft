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
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmployeeSalaryTb> EmployeeSalaryTbs { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
