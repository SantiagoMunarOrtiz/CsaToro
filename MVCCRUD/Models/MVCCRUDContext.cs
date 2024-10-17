using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCCRUD.Models
{
    public partial class MVCCRUDContext : DbContext
    {
        public MVCCRUDContext()
        {
        }

        public MVCCRUDContext(DbContextOptions<MVCCRUDContext> options)
            : base(options)
        {
        }

        // DbSet para las nuevas entidades
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedores { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasOne(v => v.Marca)
                      .WithMany(m => m.Vehiculos)
                      .HasForeignKey(v => v.MarcaId);
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(v => v.Cedula);

                entity.Property(v => v.Nombre)
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(v => v.Telefono)
                      .HasMaxLength(15)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasOne(v => v.Vehiculo)
                      .WithMany()
                      .HasForeignKey(v => v.VehiculoId);

                entity.HasOne(v => v.Vendedor)
                      .WithMany(v => v.Ventas)
                      .HasForeignKey(v => v.CedulaVendedor);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(m => m.NombreMarca)
                      .HasMaxLength(100)
                      .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
