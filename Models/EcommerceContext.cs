using System;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace E_commerce.Models
{
    public partial class EcommerceContext : IdentityDbContext<ApplicationUser>
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }


        public virtual DbSet<TbCategories> TbCategories { get; set; }

        public virtual DbSet<TbItemImages> TbItemImages { get; set; }
        public virtual DbSet<TbItems> TbItems { get; set; }

        public virtual DbSet<TbSlider> TbSlider { get; set; }
        public virtual DbSet<TbSliderCategory> TbSliderCategories { get; set; }

        public virtual DbSet<VwItemCategories> VwItemCategories { get; set; }

        public virtual DbSet<VwSliderCategories> VwSliderCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TbCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(N'')");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.ImageName).HasDefaultValueSql("(N'')");
            });



            modelBuilder.Entity<TbItems>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItems_TbCategories");
            });

            modelBuilder.Entity<TbSlider>(entity =>
            {
                entity.HasKey(e => e.SliderId);
                entity.HasOne(d => d.SliderCategory)
                    .WithMany(p => p.TbSlider)
                    .HasForeignKey(d => d.CatSliderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSlider_TbSliderCategory");
            });

            modelBuilder.Entity<TbSliderCategory>(entity =>
            {
                entity.HasKey(e => e.CatSliderId);

                entity.Property(e => e.CategorySliderName)
                    .IsRequired()
                    .HasMaxLength(100);
            });




            modelBuilder.Entity<TbItemImages>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbItemImages)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItemImages_TbItems");
            });



            modelBuilder.Entity<VwItemCategories>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwItemCategories");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(8, 2)");
            });
            modelBuilder.Entity<VwSliderCategories>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwSliderCategories");
                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CategorySliderName)

                    .HasMaxLength(100);

            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
