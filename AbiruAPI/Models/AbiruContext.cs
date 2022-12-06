using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AbiruAPI.Models
{
public partial class AbiruContext : DbContext
{
    public AbiruContext()
    {
    }

    public AbiruContext(DbContextOptions<AbiruContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colegio> Colegios { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Errores> Errores { get; set; }

    public virtual DbSet<Reconocimiento> Reconocimientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioSearch> UsuarioSearches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Abiru");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colegio>(entity =>
        {
            entity.HasKey(e => e.IdColegio).HasName("PK__Colegio__BECA32894A94A491");

            entity.ToTable("Colegio");

            entity.Property(e => e.Costo).HasColumnType("numeric(6, 2)");
            entity.Property(e => e.Direccion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Galeria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Grado)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.ImagenMain)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MallaCurr).HasColumnType("text");
            entity.Property(e => e.Matricula)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Reconocimientos).HasColumnType("text");
            entity.Property(e => e.Resena1).HasColumnType("text");
            entity.Property(e => e.Resena2).HasColumnType("text");
            entity.Property(e => e.Tipo)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.UbicacionLat).HasColumnType("numeric(20, 10)");
            entity.Property(e => e.UbicacionLong).HasColumnType("numeric(20, 10)");

            entity.HasOne(d => d.DistritoNavigation).WithMany(p => p.Colegios)
                .HasForeignKey(d => d.Distrito)
                .HasConstraintName("FK__Colegio__Distrit__29572725");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.IdDist).HasName("PK__Distrito__F1680331CBA183A8");

            entity.ToTable("Distrito");

            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Errores>(entity =>
        {
            entity.HasKey(e => e.IdError).HasName("PK__Errores__C8A4CFD9FFB49A29");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reconocimiento>(entity =>
        {
            entity.HasKey(e => e.IdReconoce).HasName("PK__Reconoci__F7F565AC94C89855");

            entity.ToTable("Reconocimiento");

            entity.Property(e => e.Imagen)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColeNavigation).WithMany(p => p.ReconocimientosNavigation)
                .HasForeignKey(d => d.IdCole)
                .HasConstraintName("FK__Reconocim__IdCol__2C3393D0");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Usuario__B7C9263845D84CEE");

            entity.ToTable("Usuario");

            entity.Property(e => e.Categoria)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.DistritoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Distrito)
                .HasConstraintName("FK__Usuario__Distrit__267ABA7A");
        });

        modelBuilder.Entity<UsuarioSearch>(entity =>
        {
            entity.HasKey(e => e.IdIdenti).HasName("PK__UsuarioS__5E5EFED90D4CD6EC");

            entity.ToTable("UsuarioSearch");

            entity.HasOne(d => d.IdColegioNavigation).WithMany(p => p.UsuarioSearches)
                .HasForeignKey(d => d.IdColegio)
                .HasConstraintName("FK__UsuarioSe__IdCol__300424B4");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioSearches)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioSe__IdUsu__2F10007B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}