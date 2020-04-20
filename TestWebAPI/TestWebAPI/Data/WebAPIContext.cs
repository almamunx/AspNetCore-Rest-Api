using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestWebAPI.Data
{
    public partial class WebAPIContext : DbContext
    {
        public WebAPIContext()
        {
        }

        public WebAPIContext(DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sample> Sample { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Web-API;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>(entity =>
            {
                entity.ToTable("sample");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
