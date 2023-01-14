using AlbumApplication.Data.Classes;
using Microsoft.EntityFrameworkCore;

namespace AlbumApplication.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Album> Albums => Set<Album>();

        public DbSet<Admin> Admins => Set<Admin>();
    }
}
