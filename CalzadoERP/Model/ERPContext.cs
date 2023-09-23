using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

public partial class ERPContext : DbContext
{
    public ERPContext()
    {
    }

    public ERPContext(DbContextOptions<ERPContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleEstilo> DetalleEstilos { get; set; }

    public virtual DbSet<Estilo> Estilos { get; set; }

    public virtual DbSet<Lote> Lotes { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Sku> Skus { get; set; }

    public virtual DbSet<Zapatero> Zapateros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=erpDB;user id=sa;password=1234;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleEstilo>(entity =>
        {
            entity.Property(e => e.IdDetalleEstilo).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdDetalleEstiloNavigation).WithOne(p => p.DetalleEstilo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalleEstilo_estilo");

            entity.HasOne(d => d.IdSkuNavigation).WithMany(p => p.DetalleEstilos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalleEstilo_sku");
        });

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasOne(d => d.IdEstiloNavigation).WithMany(p => p.Lotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lote_estilo");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.Lotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lote_orden");

            entity.HasOne(d => d.IdZapateroNavigation).WithMany(p => p.Lotes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lote_zapatero");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Ordens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_orden_cliente");
        });

        modelBuilder.Entity<Sku>(entity =>
        {
            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Skus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sku_proveedor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
