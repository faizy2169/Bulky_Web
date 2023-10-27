using AridianCRUDTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AridianCRUDTask.Data
{
    public class AridDbContext : IdentityDbContext
    {
        public AridDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<AppIdentityUser> AppIdentityUsers { get; set; }
    }
}
