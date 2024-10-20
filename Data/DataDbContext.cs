using Microsoft.EntityFrameworkCore;
namespace ToDo.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { 
        
        }
        public DbSet<Models.Task> Task { get; set; }
    }
}
