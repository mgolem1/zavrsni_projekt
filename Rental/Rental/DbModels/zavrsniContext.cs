using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Rental.DbModels
{
    public partial class zavrsniContext : DbContext
    {
        public zavrsniContext()
        {
        }

        public zavrsniContext(DbContextOptions<zavrsniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Klijent> Klijent { get; set; }
        public virtual DbSet<Mjesto> Mjesto { get; set; }
        public virtual DbSet<NacinPlacanja> NacinPlacanja { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Vozilo> Vozilo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=zavrsni;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.HasKey(e => e.Idkategorija)
                    .HasName("PK__Kategori__7E48B6E5F7D0FE93");

                entity.Property(e => e.Idkategorija).HasColumnName("IDKategorija");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.HasKey(e => e.Idklijent)
                    .HasName("PK__Klijent__0769C703201E9FEA");

                entity.Property(e => e.Idklijent).HasColumnName("IDKlijent");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mjesto>(entity =>
            {
                entity.HasKey(e => e.Idmjesto)
                    .HasName("PK__Mjesto__2CC2E480547B6EB9");

                entity.Property(e => e.Idmjesto).HasColumnName("IDMjesto");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NacinPlacanja>(entity =>
            {
                entity.HasKey(e => e.IdnacinPlacanja)
                    .HasName("PK__NacinPla__D431C3C9F34CB413");

                entity.Property(e => e.IdnacinPlacanja).HasColumnName("IDNacinPlacanja");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.HasKey(e => e.Idrezervacija)
                    .HasName("PK__Rezervac__21D11B290805B468");

                entity.Property(e => e.Idrezervacija).HasColumnName("IDRezervacija");

                entity.Property(e => e.DatumDo).HasColumnType("datetime");

                entity.Property(e => e.DatumOd).HasColumnType("datetime");

                entity.HasOne(d => d.KlijentNavigation)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.Klijent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezervaci__Klije__30F848ED");

                entity.HasOne(d => d.MjestoPovrataNavigation)
                    .WithMany(p => p.RezervacijaMjestoPovrataNavigation)
                    .HasForeignKey(d => d.MjestoPovrata)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezervaci__Mjest__2F10007B");

                entity.HasOne(d => d.MjestoPreuzimanjaNavigation)
                    .WithMany(p => p.RezervacijaMjestoPreuzimanjaNavigation)
                    .HasForeignKey(d => d.MjestoPreuzimanja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezervaci__Mjest__2E1BDC42");

                entity.HasOne(d => d.NacinNavigation)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.Nacin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezervaci__Nacin__31EC6D26");

                entity.HasOne(d => d.VoziloNavigation)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.Vozilo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezervaci__Vozil__300424B4");

                entity.Property(e => e.CijenaRez)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Vozilo>(entity =>
            {
                entity.HasKey(e => e.Idvozilo)
                    .HasName("PK__Vozilo__2A0736848F114D28");

                entity.Property(e => e.Idvozilo).HasColumnName("IDVozilo");

                entity.Property(e => e.Kategorija).HasColumnName("kategorija");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Registracija)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.KategorijaNavigation)
                    .WithMany(p => p.Vozilo)
                    .HasForeignKey(d => d.Kategorija)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vozilo__kategori__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
