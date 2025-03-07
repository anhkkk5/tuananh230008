using GoodsManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace GoodsManagementAPI.Data
{
    public class GoodsDbContext : DbContext
    {
        public GoodsDbContext(DbContextOptions<GoodsDbContext> options) : base(options) { }

        public DbSet<HangHoa> Goods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HangHoa>().HasKey(h => h.MaHangHoa);
        }
    }
}