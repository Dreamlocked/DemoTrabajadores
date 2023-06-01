using System;
using System.Collections.Generic;
using DemoTrabajadores.Models.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace DemoTrabajadores.Models;

public partial class DemoTrabajadoresContext : DbContext
{
    public DemoTrabajadoresContext()
    {
    }

    public DemoTrabajadoresContext(DbContextOptions<DemoTrabajadoresContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Trabajador> Trabajadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento);

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamento).ValueGeneratedNever();
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(350)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => new { e.IdDistrito, e.IdProvincia }).HasName("PK_Distrito_1");

            entity.ToTable("Distrito");

            entity.HasIndex(e => e.IdDistrito, "UQ_Distrito").IsUnique();

            entity.Property(e => e.NombreDistrito)
                .HasMaxLength(350)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Distritos)
                .HasPrincipalKey(p => p.IdProvincia)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincia");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => new { e.IdProvincia, e.IdDepartamento });

            entity.HasIndex(e => e.IdProvincia, "UQ_Provincia").IsUnique();

            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(350)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departamento");
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.HasKey(e => e.IdTrabajador);

            entity.ToTable("Trabajador");

            entity.Property(e => e.Nombres)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Trabajadors)
                .HasPrincipalKey(p => p.IdDistrito)
                .HasForeignKey(d => d.IdDistrito)
                .HasConstraintName("FK_Distrito");
        });
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<TrabajadorDTO>(entity =>
        {
            entity.HasKey(e => e.IdTrabajador);
        });

        modelBuilder.Entity<TrabajadorDTO>().ToSqlQuery("EXEC [dbo].[SP_LISTAR_TRABAJADORES]");

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
