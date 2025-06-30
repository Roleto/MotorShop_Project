using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.Entities;

namespace MotorShop_Project.Data.DBContext
{
    public class MotorShopDbContext : DbContext
    {
        public MotorShopDbContext(DbContextOptions<MotorShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<ModelEntity> Models { get; set; }
        public DbSet<ExtrasEntity> Extras { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === BRAND → MODEL (Cascade Delete)
            modelBuilder.Entity<ModelEntity>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            // === MODEL → EXTRAS (Cascade Delete)
            modelBuilder.Entity<ExtrasEntity>()
                .HasOne(e => e.Model)
                .WithMany(m => m.Extras)
                .HasForeignKey(e => e.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            // === ORDER → BRAND (Restrict)
            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Brand)
                .WithMany()
                .HasForeignKey(o => o.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            // === ORDER → MODEL (Restrict)
            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Model)
                .WithMany()
                .HasForeignKey(o => o.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            // === ORDER → EXTRAS (Many-to-Many, explicit table)
            modelBuilder.Entity<OrderEntity>()
                .HasMany(o => o.Extras)
                .WithMany()
                .UsingEntity(j => j.ToTable("OrderExtras"));

            // === DEFAULT VALUE (OrderTime)
            modelBuilder.Entity<OrderEntity>()
                .Property(o => o.OrderTime)
                .HasDefaultValueSql("GETUTCDATE()");

            // === INDEXEK
            modelBuilder.Entity<BrandEntity>()
                .HasIndex(b => b.Name);

            modelBuilder.Entity<ModelEntity>()
                .HasIndex(m => m.Name);

            modelBuilder.Entity<ExtrasEntity>()
                .HasIndex(e => e.Type);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine);
#endif
        }
    }

}
