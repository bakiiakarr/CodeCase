using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConfigWebAPI.Models;

public partial class ConfigDb1Context : DbContext
{
    public ConfigDb1Context()
    {
    }

    public ConfigDb1Context(DbContextOptions<ConfigDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Configuration> Configurations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC07CE57B941");

            entity.Property(e => e.ApplicationName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.Value).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
