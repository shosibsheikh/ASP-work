using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ImageUplodeASP.Models;

public partial class ImagedbContext : DbContext
{
    public ImagedbContext()
    {
    }

    public ImagedbContext(DbContextOptions<ImagedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3214EC078BD27DE9");

            entity.ToTable("product");

            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image_path");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
