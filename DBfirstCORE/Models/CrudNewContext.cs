using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBfirstCORE.Models;

public partial class CrudNewContext : DbContext
{
    public CrudNewContext()
    {
    }

    public CrudNewContext(DbContextOptions<CrudNewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassTbl> ClassTbls { get; set; }

    public virtual DbSet<EmpTbl> EmpTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
       
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__class_tb__3213E83FC7D9BF2B");

            entity.ToTable("class_tbl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Add).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<EmpTbl>(entity =>
        {
            entity.ToTable("Emp_tbl");

            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
