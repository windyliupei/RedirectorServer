using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class EACDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=.;Database=EACDB;User ID=sa;Password=AAaa1111;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EncryptionKeys>(entity =>
            {
                entity.HasKey(e => e.EncryptionKeyId)
                    .HasName("PK_EncryptionKeys");

                entity.HasIndex(e => e.MacId)
                    .HasName("UQ_KeyMacID")
                    .IsUnique();

                entity.Property(e => e.EncryptionKeyId).HasColumnName("EncryptionKeyID");

                entity.Property(e => e.EncryptionKey)
                    .IsRequired()
                    .HasColumnType("binary(128)");

                entity.Property(e => e.MacId)
                    .IsRequired()
                    .HasColumnName("MacID")
                    .HasColumnType("varchar(50)");
            });
        }

        public virtual DbSet<EncryptionKeys> EncryptionKeys { get; set; }
    }
}