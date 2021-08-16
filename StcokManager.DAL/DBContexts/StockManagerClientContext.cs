using Microsoft.EntityFrameworkCore;

namespace StockManager.Client.Data
{
    public class StockManagerClientContext : DbContext
    {
        public StockManagerClientContext(DbContextOptions<StockManagerClientContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<StcokManager.DAL.Entities.Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StcokManager.DAL.Entities.Stock>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Id");
            });
        }
    }
}
