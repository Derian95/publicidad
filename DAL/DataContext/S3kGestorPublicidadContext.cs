using System;
using System.Collections.Generic;
using GestorPublicidad.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorPublicidad.DAL.DataContext;

public partial class S3kGestorPublicidadContext : DbContext
{
    public S3kGestorPublicidadContext()
    {
    }

    public S3kGestorPublicidadContext(DbContextOptions<S3kGestorPublicidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ImagenVideo> ImagenVideos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ImagenVideo>(entity =>
        {
            entity.HasKey(e => e.IdImagenVideo).HasName("PK__ImagenVi__44416D9B2F5AF89B");

            entity.ToTable("ImagenVideo");

            entity.Property(e => e.IdImagenVideo).HasColumnName("idImagenVideo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
