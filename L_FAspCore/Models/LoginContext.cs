using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace L_FAspCore.Models;

public partial class LoginContext : DbContext
{
    public LoginContext()
    {
    }

    public LoginContext(DbContextOptions<LoginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoginTbl> LoginTbls { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__loginTbl__3213E83F860F4652");

            entity.ToTable("loginTbl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User_tbl");

            entity.ToTable("User_Tbl");

            entity.Property(e => e.Add)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
