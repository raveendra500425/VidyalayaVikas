using Microsoft.EntityFrameworkCore;

namespace VV.ModelsEntity
{
    public class VVDbContext : DbContext
    {
        public VVDbContext(DbContextOptions<VVDbContext> options) : base(options) { }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Class { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define model configurations here
        }
    }
}


//Add-Migration InitialCreate
//Update-Database
//Add-Migration AddErrorLogTable
//Update-Database