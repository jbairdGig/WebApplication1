using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
        {
        }

        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Wkprofile> Wkprofile { get; set; }
        public virtual DbSet<Worksite> Worksite { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wkprofile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.ToTable("WKProfile");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.BackgroundPic)
                    .HasColumnName("background_pic")
                    .HasMaxLength(150);

                entity.Property(e => e.WorksiteId).HasColumnName("worksite_id");

                entity.HasOne(d => d.Worksite)
                    .WithMany(p => p.Wkprofile)
                    .HasForeignKey(d => d.WorksiteId)
                    .HasConstraintName("FK_WKProfile_Worksite");
            });

            modelBuilder.Entity<Worksite>(entity =>
            {
                entity.Property(e => e.WorksiteId).HasColumnName("worksite_id");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(150);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Worksite)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Worksite_Users");
            });
        }
    }
}
