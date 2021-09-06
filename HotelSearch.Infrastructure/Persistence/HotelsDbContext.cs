using HotelSearch.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelSearch.Infrastructure.Persistence
{
    public class HotelsDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
       
        public HotelsDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(ConfigureHotelModel);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureHotelModel(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);
        }

        #endregion
    }
}
