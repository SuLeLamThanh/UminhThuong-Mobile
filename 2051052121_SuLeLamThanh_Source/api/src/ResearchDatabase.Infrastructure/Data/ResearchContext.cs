using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ResearchDatabase.Domain.Entities;

namespace ResearchDatabase.Infrastructure.Data;

public class ResearchDbContext : DbContext
{
    public ResearchDbContext(DbContextOptions<ResearchDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        // Bỏ qua cảnh báo PendingModelChangesWarning
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
    public DbSet<Kingdom> Kingdoms { get; set; }
    public DbSet<Phylum> Phyla { get; set; }
    public DbSet<Class> Classes { get; set; } // Đổi tên từ 'Class' thành 'Classes'
    public DbSet<Order> Orders { get; set; } // Đổi tên từ 'Order' thành 'Orders'
    public DbSet<Family> Families { get; set; } // Đổi tên từ 'Family' thành 'Families'
    public DbSet<Genus> Genera { get; set; } // Đổi tên từ 'Genus' thành 'Genera'
    public DbSet<Species> Species { get; set; }
    public DbSet<ConservationStatus> ConservationStatus { get; set; }
    public DbSet<Characteristic> Characteristics { get; set; }
    public DbSet<Habitat> Habitats { get; set; }
    public DbSet<SpeciesHabitat> SpeciesHabitats { get; set; }
    public DbSet<GeographicDistribution> GeographicDistributions { get; set; }
    public DbSet<ResearchSubject> ResearchSubjects { get; set; }
    public DbSet<ResearchRecord> ResearchRecords { get; set; }
    public DbSet<ResearchRecordAuthor> ResearchRecordAuthors { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<OrganismGroup> OrganismGroups { get; set; }
    public DbSet<OrganismGroupSpecies> OrganismGroupSpecies { get; set; }
    public DbSet<SpeciesAuthor> SpeciesAuthors { get; set; }
    public DbSet<ResearchRecordSpecies> ResearchRecordSpecies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Kingdom Configuration
        modelBuilder.Entity<Kingdom>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
        });

        // Phylum Configuration
        modelBuilder.Entity<Phylum>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.HasOne(e => e.Kingdom)
                  .WithMany(k => k.Phyla)
                  .HasForeignKey(e => e.KingdomId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Class Configuration
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.HasOne(e => e.Phylum)
                  .WithMany(p => p.Classes)
                  .HasForeignKey(e => e.PhylumId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Order Configuration
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.HasOne(e => e.Class)
                  .WithMany(c => c.Orders)
                  .HasForeignKey(e => e.ClassId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Family Configuration
        modelBuilder.Entity<Family>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.HasOne(e => e.Order)
                  .WithMany(o => o.Families)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Genus Configuration
        modelBuilder.Entity<Genus>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.HasOne(e => e.Family)
                  .WithMany(f => f.Genera)
                  .HasForeignKey(e => e.FamilyId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Species Configuration
        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ScientificName).IsRequired().HasMaxLength(255);
            entity.Property(e => e.CommonName).HasMaxLength(255);
            entity.Property(e => e.ImageUrl).HasMaxLength(2048);
            

            entity.HasOne(e => e.Genus)
                  .WithMany(g => g.Species)
                  .HasForeignKey(e => e.GenusId)
                  .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.ConservationStatus)
                  .WithMany(c => c.Species)
                  .HasForeignKey(e => e.ConservationStatusId)
                  .OnDelete(DeleteBehavior.SetNull);
            entity.HasMany(s => s.ResearchRecordSpecies)
        .WithOne(rrs => rrs.Species)
        .HasForeignKey(rrs => rrs.SpeciesId);
        });

        // ConservationStatus Configuration
        modelBuilder.Entity<ConservationStatus>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Severity).HasMaxLength(50);
        });

        // Habitat Configuration
        modelBuilder.Entity<Habitat>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Climate).HasMaxLength(100);
        });

        // SpeciesHabitat Configuration
        modelBuilder.Entity<SpeciesHabitat>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Species)
                  .WithMany(s => s.SpeciesHabitats)
                  .HasForeignKey(e => e.SpeciesId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Habitat)
                  .WithMany(h => h.SpeciesHabitats)
                  .HasForeignKey(e => e.HabitatId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // GeographicDistribution Configuration
        modelBuilder.Entity<GeographicDistribution>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Region).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasOne(e => e.Species)
                  .WithMany(s => s.GeographicDistributions)
                  .HasForeignKey(e => e.SpeciesId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ResearchSubject Configuration
        modelBuilder.Entity<ResearchSubject>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Project).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TeamMembers).HasMaxLength(1000);
        });

        // ResearchRecord Configuration
        modelBuilder.Entity<ResearchRecord>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.Result).HasMaxLength(1000);

            entity.HasOne(e => e.ResearchSubject)
                  .WithMany(r => r.ResearchRecords)
                  .HasForeignKey(e => e.ResearchSubjectId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // Author Configuration
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Affiliation).HasMaxLength(255);
        });

        // ResearchRecordAuthor Configuration
        modelBuilder.Entity<ResearchRecordAuthor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.ResearchRecord)
                  .WithMany(r => r.ResearchRecordAuthors)
                  .HasForeignKey(e => e.ResearchRecordId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Author)
                  .WithMany(a => a.ResearchRecordAuthors)
                  .HasForeignKey(e => e.AuthorId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Characteristic Configuration
        modelBuilder.Entity<Characteristic>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CharacteristicType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(255);
            entity.Property(e => e.Units).HasMaxLength(50);

            entity.HasOne(e => e.Species)
                  .WithMany(s => s.Characteristics)
                  .HasForeignKey(e => e.SpeciesId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // OrganismGroup Configuration
        modelBuilder.Entity<OrganismGroup>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Symbol).HasMaxLength(50);
        });

        // OrganismGroupSpecies Configuration
        modelBuilder.Entity<OrganismGroupSpecies>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.OrganismGroup)
                  .WithMany(o => o.OrganismGroupSpecies)
                  .HasForeignKey(e => e.OrganismGroupId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Species)
                  .WithMany(s => s.OrganismGroupSpecies)
                  .HasForeignKey(e => e.SpeciesId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // SpeciesAuthor Configuration
        modelBuilder.Entity<SpeciesAuthor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Species)
                  .WithMany(s => s.SpeciesAuthors)
                  .HasForeignKey(e => e.SpeciesId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Author)
                  .WithMany(a => a.SpeciesAuthors)
                  .HasForeignKey(e => e.AuthorId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        // Configure ResearchRecordSpecies relationships
        modelBuilder.Entity<ResearchRecordSpecies>()
            .HasKey(rrs => rrs.Id);

        modelBuilder.Entity<ResearchRecordSpecies>()
            .HasOne(rrs => rrs.ResearchRecord)
            .WithMany(rr => rr.ResearchRecordSpecies)
            .HasForeignKey(rrs => rrs.ResearchRecordId);
        DatabaseSeeder.SeedData(modelBuilder);
    }
}