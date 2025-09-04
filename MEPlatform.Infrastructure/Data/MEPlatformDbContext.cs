using MEPlatform.Core.Entities;
using MEPlatform.Core.Entities.Associations;
using MEPlatform.Core.Entities.Framework;
using MEPlatform.Core.Entities.Identity;
using MEPlatform.Core.Entities.Project;
using MEPlatform.Core.Entities.Setup;
using MEPlatform.Core.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MEPlatform.Infrastructure.Data;

public class MEPlatformDbContext : IdentityDbContext<ApplicationUser>
{
    public MEPlatformDbContext(DbContextOptions<MEPlatformDbContext> options) : base(options) { }
    
    // Framework entities
    public DbSet<Framework> Frameworks { get; set; }
    public DbSet<FrameworkElement> FrameworkElements { get; set; }
    public DbSet<Indicator> Indicators { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    
    // Setup entities
    public DbSet<Region> Regions { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<Donor> Donors { get; set; }
    public DbSet<Unit> Units { get; set; }
    
    // Project entities
    public DbSet<Program> Programs { get; set; }
    public DbSet<ActionPlan> ActionPlans { get; set; }
    public DbSet<Dimension> Dimensions { get; set; }
    public DbSet<LogicalFramework> LogicalFrameworks { get; set; }
    public DbSet<LogicalFrameworkIndicator> LogicalFrameworkIndicators { get; set; }
    public DbSet<ProjectFile> ProjectFiles { get; set; }
    
    // Association entities
    public DbSet<ProjectAlignment> ProjectAlignments { get; set; }
    public DbSet<ProjectRegion> ProjectRegions { get; set; }
    public DbSet<ProjectSector> ProjectSectors { get; set; }
    public DbSet<ProjectPartner> ProjectPartners { get; set; }
    public DbSet<ProjectDonor> ProjectDonors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Framework hierarchical relationship
        modelBuilder.Entity<FrameworkElement>()
            .HasOne(e => e.Parent)
            .WithMany(e => e.Children)
            .HasForeignKey(e => e.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Region hierarchical relationship
        modelBuilder.Entity<Region>()
            .HasOne(r => r.Parent)
            .WithMany(r => r.Children)
            .HasForeignKey(r => r.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Configure decimal precision
        modelBuilder.Entity<Framework>()
            .Property(f => f.Weight)
            .HasPrecision(18, 4);
            
        modelBuilder.Entity<FrameworkElement>()
            .Property(f => f.Weight)
            .HasPrecision(18, 4);
            
        modelBuilder.Entity<Indicator>()
            .Property(i => i.Weight)
            .HasPrecision(18, 4);
        
        // Configure indexes for performance
        modelBuilder.Entity<FrameworkElement>()
            .HasIndex(e => e.FrameworkId);
        
        modelBuilder.Entity<FrameworkElement>()
            .HasIndex(e => e.ParentId);
        
        modelBuilder.Entity<Measurement>()
            .HasIndex(m => new { m.IndicatorId, m.Date });
        
        // Configure foreign key relationships
        modelBuilder.Entity<ProjectAlignment>()
            .HasOne(pa => pa.Program)
            .WithMany(p => p.ProjectAlignments)
            .HasForeignKey(pa => pa.ProgramId);
            
        modelBuilder.Entity<ProjectAlignment>()
            .HasOne(pa => pa.Framework)
            .WithMany(f => f.ProjectAlignments)
            .HasForeignKey(pa => pa.FrameworkId)
            .OnDelete(DeleteBehavior.SetNull);
            
        modelBuilder.Entity<ProjectAlignment>()
            .HasOne(pa => pa.FrameworkElement)
            .WithMany(fe => fe.ProjectAlignments)
            .HasForeignKey(pa => pa.FrameworkElementId)
            .OnDelete(DeleteBehavior.SetNull);
        
        // Seed initial data
        SeedInitialData(modelBuilder);
    }
    
    private void SeedInitialData(ModelBuilder modelBuilder)
    {
        // Seed the 3 frameworks
        modelBuilder.Entity<Framework>().HasData(
            new Framework 
            { 
                Id = 1, 
                Name = "Syria's National Development Vision Results Framework", 
                Type = FrameworkType.SNDV, 
                Weight = 1.0m, 
                CreatedAt = DateTime.UtcNow 
            },
            new Framework 
            { 
                Id = 2, 
                Name = "Programs Framework Results Framework", 
                Type = FrameworkType.PF, 
                Weight = 1.0m, 
                CreatedAt = DateTime.UtcNow 
            },
            new Framework 
            { 
                Id = 3, 
                Name = "Sustainable Development Goals", 
                Type = FrameworkType.SDG, 
                Weight = 1.0m, 
                CreatedAt = DateTime.UtcNow 
            }
        );
        
        // Seed some basic regions
        modelBuilder.Entity<Region>().HasData(
            new Region { Id = 1, Name = "Damascus", Type = "Province", CreatedAt = DateTime.UtcNow },
            new Region { Id = 2, Name = "Aleppo", Type = "Province", CreatedAt = DateTime.UtcNow },
            new Region { Id = 3, Name = "Homs", Type = "Province", CreatedAt = DateTime.UtcNow },
            new Region { Id = 4, Name = "Latakia", Type = "Province", CreatedAt = DateTime.UtcNow },
            new Region { Id = 5, Name = "Daraa", Type = "Province", CreatedAt = DateTime.UtcNow }
        );
        
        // Seed basic sectors
        modelBuilder.Entity<Sector>().HasData(
            new Sector { Id = 1, Name = "Education", CreatedAt = DateTime.UtcNow },
            new Sector { Id = 2, Name = "Health", CreatedAt = DateTime.UtcNow },
            new Sector { Id = 3, Name = "Infrastructure", CreatedAt = DateTime.UtcNow },
            new Sector { Id = 4, Name = "Agriculture", CreatedAt = DateTime.UtcNow },
            new Sector { Id = 5, Name = "Water and Sanitation", CreatedAt = DateTime.UtcNow }
        );
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
        
        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            
            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}