using System;
using System.Collections.Generic;
using EcoPets.model.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoPets.repositorio.DBContext.Data;

public partial class EcopetsContext : DbContext
{
    public EcopetsContext()
    {
    }

    public EcopetsContext(DbContextOptions<EcopetsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TipoComprobante> TipoComprobantes { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10951FB18E");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DetalleV__AAA5CEC26C10656D");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetalleVe__IdPro__71D1E811");

            entity.HasOne(d => d.IdTipoComprobanteNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdTipoComprobante)
                .HasConstraintName("FK__DetalleVe__IdTip__74AE54BC");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__DetalleVe__IdVen__70DDC3D8");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210409F8841");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioOferta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Producto__IdCate__4D94879B");
        });

        modelBuilder.Entity<TipoComprobante>(entity =>
        {
            entity.HasKey(e => e.IdTipoComprobante).HasName("PK__TipoComp__F8411DEBB0C0E26A");

            entity.ToTable("TipoComprobante");

            entity.Property(e => e.CTipoComprobante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cTipoComprobante");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__TipoDocu__3AB3332F614E99E5");

            entity.ToTable("TipoDocumento");

            entity.Property(e => e.CTipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cTipoDocumento");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97465A5E3B");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FK__Usuario__IdTipoD__5812160E");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__BC1240BD7214C71A");

            entity.Property(e => e.IdVenta).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Venta__IdUsuario__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
