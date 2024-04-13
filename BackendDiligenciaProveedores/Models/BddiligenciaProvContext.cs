using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendDiligenciaProveedores.Models;

public partial class BddiligenciaProvContext : DbContext
{
    public BddiligenciaProvContext()
    {
    }

    public BddiligenciaProvContext(DbContextOptions<BddiligenciaProvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Proveedor> Proveedores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=BDDiligenciaProv; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB9C57F8916");

            entity.ToTable("Proveedor");

            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.CorreoElectronico).HasMaxLength(255);
            entity.Property(e => e.DireccionFisica).HasMaxLength(255);
            entity.Property(e => e.FacturacionAnual).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaUltimaEdicion).HasColumnType("datetime");
            entity.Property(e => e.NombreComercial).HasMaxLength(255);
            entity.Property(e => e.NumeroTelefonico).HasMaxLength(20);
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
            entity.Property(e => e.SitioWeb).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7989F98CE5F");

            entity.ToTable("User");

            entity.HasIndex(e => e.Usuario, "UQ__Usuarios__E3237CF788B2D711").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Contrasenia).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
            entity.Property(e => e.Usuario).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
