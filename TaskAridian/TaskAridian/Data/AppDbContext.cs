using Microsoft.EntityFrameworkCore;
using TaskAridian.Models;

namespace TaskAridian.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
