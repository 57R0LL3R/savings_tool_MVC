using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace savings_tool_dotnet_MVC_.Models;

public partial class SavingsToolContext : DbContext
{
    public SavingsToolContext()
    {
    }

    public SavingsToolContext(DbContextOptions<SavingsToolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Datum> Data { get; set; }

    public virtual DbSet<Money> Money { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Datum>(entity =>
        {
            entity.HasKey(e => e.IdData);

            entity.Property(e => e.IdData).HasColumnName("Id_Data");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Money>(entity =>
        {
            entity.HasKey(e => e.IdMoney);

            entity.Property(e => e.IdMoney)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Money");
            entity.Property(e => e.QuantityMoney).HasColumnName("Quantity_Money");
            entity.Property(e => e.TotalValue).HasColumnName("Total_Value");
            entity.Property(e => e.ValueMoney).HasColumnName("Value_Money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
