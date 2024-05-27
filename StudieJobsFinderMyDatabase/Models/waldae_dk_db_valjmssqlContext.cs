using Microsoft.EntityFrameworkCore;
using StudieJobsFinderMyDatabase.Models;

public partial class waldae_dk_db_valjmssqlContext : DbContext
{
    public waldae_dk_db_valjmssqlContext()
    {
    }

    public waldae_dk_db_valjmssqlContext(DbContextOptions<waldae_dk_db_valjmssqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Job> Jobs { get; set; }
    public virtual DbSet<Studerende> Studerendes { get; set; }
    public virtual DbSet<Virksomhed> Virksomheds { get; set; }
    public virtual DbSet<Bruger> Brugers { get; set; } // Tilføjet denne linje

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=mssql16.unoeuro.com;Initial Catalog=waldae_dk_db_valjmssql;Persist Security Info=True;User ID=waldae_dk;Password=fea96bBcdEtyhH35kzRm;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__Job__056690E28CE19861");

            entity.Property(e => e.JobId).ValueGeneratedNever();

            entity.HasOne(d => d.Virksomheds).WithMany(p => p.Jobs).HasConstraintName("FK__Job__Kategori__286302EC");
        });

        modelBuilder.Entity<Studerende>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Studeren__32C52A79D1B1B207");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.Køn).IsFixedLength();
        });

        modelBuilder.Entity<Virksomhed>(entity =>
        {
            entity.HasKey(e => e.VirksomhedsId).HasName("PK__Virksomh__13BF558624D1646C");

            entity.Property(e => e.VirksomhedsId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Bruger>(entity =>
        {
            entity.HasKey(e => e.BrugerId).HasName("PK__Bruger__13BF5586A4E2F1ED");

            entity.Property(e => e.BrugerId).ValueGeneratedOnAdd(); // Sørg for, at ID'et er auto-genereret
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}