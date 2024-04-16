using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace PowerTools.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<User> Users { get; set; }
        // Добавьте DbSet для вашей собственной сущности, если есть
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
   
}
