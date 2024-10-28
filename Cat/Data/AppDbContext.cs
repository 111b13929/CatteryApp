using Microsoft.EntityFrameworkCore;

namespace CatteryApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CatteryApp.Models.Cat> Cats { get; set; } // 使用完整名稱

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatteryApp.Models.Cat>().ToTable("Cats"); // 明確指定資料表名稱
        }
    }
}
