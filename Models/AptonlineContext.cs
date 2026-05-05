using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WEBAPISP_CRUDAPP.Models;

public partial class AptonlineContext : DbContext
{
    public AptonlineContext()
    {
    }

    public AptonlineContext(DbContextOptions<AptonlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aptest> Aptests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=APTONLINE;Integrated Security=True;Encrypt=False;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aptest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__APTEST__3214EC27F4CAC893");

            entity.ToTable("APTEST");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Modules)
                .HasMaxLength(40)
                .HasColumnName("modules");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
