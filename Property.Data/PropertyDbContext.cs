using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Property.Model;
using System.Reflection.Emit;

namespace Property.Data
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Propertys> properties { get; set; }

        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<PropertyStatusType> PropertyStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propertys>()
                .HasOne(p => p.PropertyType)
                .WithMany()
                .HasForeignKey(p => p.PropertyTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Propertys>()
                .HasOne(p => p.PropertyStatusType)
                .WithMany()
                .HasForeignKey(p => p.PropertyStatusId)
                .HasForeignKey(p => p.PropertyStatusId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

