using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vizsga_alap_backend.Models;

public partial class VizsgaContext : DbContext
{
    public VizsgaContext()
    {
    }

    public VizsgaContext(DbContextOptions<VizsgaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategorium> Kategoria { get; set; }

    public virtual DbSet<Teszt> Teszts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=vizsga;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kategori__3213E83F99093144");

            entity.ToTable("kategoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Kategorianev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("kategorianev");
            entity.Property(e => e.Timestamps)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("timestamps");
        });

        modelBuilder.Entity<Teszt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teszt__3213E83F12B8AC52");

            entity.ToTable("teszt", tb => tb.HasTrigger("alapHelyesValasz"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Helyes)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("helyes");
            entity.Property(e => e.KategoriaId).HasColumnName("kategoriaId");
            entity.Property(e => e.Kerdes)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("kerdes");
            entity.Property(e => e.Timestamps)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("timestamps");
            entity.Property(e => e.V1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("v1");
            entity.Property(e => e.V2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("v2");
            entity.Property(e => e.V3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("v3");
            entity.Property(e => e.V4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("v4");

            entity.HasOne(d => d.Kategoria).WithMany(p => p.Teszts)
                .HasForeignKey(d => d.KategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teszt__timestamp__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
