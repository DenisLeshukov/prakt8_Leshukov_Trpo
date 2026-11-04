using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prakt8_leshukov.Models;

public partial class Prakt8Context : DbContext
{
    public Prakt8Context()
    {
    }

    public Prakt8Context(DbContextOptions<Prakt8Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=prakt8; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");
            entity.HasKey(t => t.Id);
            entity.Property(e => e.Title).HasColumnName("TItle");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
