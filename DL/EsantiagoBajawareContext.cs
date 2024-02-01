using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class EsantiagoBajawareContext : DbContext
{
    public EsantiagoBajawareContext()
    {
    }

    public EsantiagoBajawareContext(DbContextOptions<EsantiagoBajawareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Credito> Creditos { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    public virtual DbSet<TipoCredito> TipoCreditos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= ESantiagoBajaware; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CodCliente).HasName("PK__Cliente__DF8324D75BC8ABF8");

            entity.ToTable("Cliente");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoCivilNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEstadoCivil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__IdEstad__164452B1");

            entity.HasOne(d => d.IdNacionalidadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdNacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__IdNacio__173876EA");
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasKey(e => e.CodCredito).HasName("PK__Credito__5F5009CB75EDB489");

            entity.ToTable("Credito");

            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.Monto).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.CodClienteNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.CodCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Credito__CodClie__1A14E395");

            entity.HasOne(d => d.IdTipoCreditoNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdTipoCredito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Credito__IdTipoC__1B0907CE");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCivil).HasName("PK__EstadoCi__889DE1B29D338A2B");

            entity.ToTable("EstadoCivil");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity.HasKey(e => e.IdNacionalidad).HasName("PK__Nacional__021E36BE109E7ED6");

            entity.ToTable("Nacionalidad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoCredito>(entity =>
        {
            entity.HasKey(e => e.IdTipoCredito).HasName("PK__TipoCred__24CBCF7A3844265F");

            entity.ToTable("TipoCredito");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
