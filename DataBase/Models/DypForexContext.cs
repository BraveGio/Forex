using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBase.Models
{
    public partial class DypForexContext : DbContext
    {
        public virtual DbSet<NazwyWalut> NazwyWalut { get; set; }
        public virtual DbSet<TabelaKursów> TabelaKursów { get; set; }
        public virtual DbSet<Użytkownik> Użytkownik { get; set; }

        // Unable to generate entity type for table 'dbo.Operacje'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Logowanie'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=sqltester.wwsi.edu.pl;Database=DypForex;User Id=akita;Password=zielonamewa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NazwyWalut>(entity =>
            {
                entity.HasKey(e => e.IdWaluty);

                entity.Property(e => e.IdWaluty)
                    .HasColumnName("idWaluty")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaWaluty)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabelaKursów>(entity =>
            {
                entity.HasKey(e => e.IdRecord);

                entity.Property(e => e.IdRecord).HasColumnName("idRecord");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.HasOne(d => d.WalutaNavigation)
                    .WithMany(p => p.TabelaKursów)
                    .HasForeignKey(d => d.Waluta)
                    .HasConstraintName("FK_TabelaKursów_NazwyWalut");
            });

            modelBuilder.Entity<Użytkownik>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
