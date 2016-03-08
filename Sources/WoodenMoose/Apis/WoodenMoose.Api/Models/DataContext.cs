using Microsoft.Data.Entity;

namespace WoodenMoose.Api.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                        .HasKey(x => x.Id);
        }
    }
}
