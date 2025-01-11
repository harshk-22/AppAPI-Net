using AppAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext( DbContextOptions options):base(options)
        {
            
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
