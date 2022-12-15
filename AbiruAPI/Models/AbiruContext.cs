using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AbiruAPI.Models;

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

    public virtual DbSet<Reclamo> Reclamos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioSearch> UsuarioSearches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Abiru");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colegio>(entity =>
        {
            entity.HasKey(e => e.IdColegio).HasName("PK__Colegio__BECA328995FCB47F");

            entity.ToTable("Colegio");

            entity.Property(e => e.Costo).HasColumnType("numeric(7, 2)");
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.DireccionX).HasColumnType("numeric(18, 16)");
            entity.Property(e => e.DireccionY).HasColumnType("numeric(18, 16)");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Grado)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Horario).HasColumnType("text");
            entity.Property(e => e.ImagenDirect)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImagenInfo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImagenPrinc)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImagenRecoA)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImagenRecoB)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImagenRecoC)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImagenResA)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImagenResB)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Informacion).HasColumnType("text");
            entity.Property(e => e.MallaCurricular).HasColumnType("text");
            entity.Property(e => e.Mision).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Reconocimiento).HasColumnType("text");
            entity.Property(e => e.Religion).HasColumnType("text");
            entity.Property(e => e.ResenaA).HasColumnType("text");
            entity.Property(e => e.ResenaB).HasColumnType("text");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Vision).HasColumnType("text");

            entity.HasOne(d => d.DistritoNavigation).WithMany(p => p.Colegios)
                .HasForeignKey(d => d.Distrito)
                .HasConstraintName("FK__Colegio__Distrit__398D8EEE");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.IdDist).HasName("PK__Distrito__F1680331CBA183A8");

            entity.ToTable("Distrito");

            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reclamo>(entity =>
        {
            entity.HasKey(e => e.IdReclamo).HasName("PK__Reclamos__19682C66EC20B8D5");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reclamos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Reclamos__IdUsua__403A8C7D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF971E2CF17B");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellido)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Categoria)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("DNI");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.DistritoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Distrito)
                .HasConstraintName("FK__Usuario__Distrit__36B12243");
        });

        modelBuilder.Entity<UsuarioSearch>(entity =>
        {
            entity.HasKey(e => e.IdUs).HasName("PK__UsuarioS__B7700246612ACD5E");

            entity.ToTable("UsuarioSearch");

            entity.Property(e => e.IdUs).HasColumnName("IdUS");

            entity.HasOne(d => d.IdColegioNavigation).WithMany(p => p.UsuarioSearches)
                .HasForeignKey(d => d.IdColegio)
                .HasConstraintName("FK__UsuarioSe__IdCol__3D5E1FD2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioSearches)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioSe__IdUsu__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
