using MEPlatform.Core.Entities.Associations;

namespace MEPlatform.Core.Entities.Project;

public class Program : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Status1 { get; set; } = string.Empty;
    public string Status2 { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal EstimatedBudget { get; set; }
    public decimal RealBudget { get; set; }
    
    // Performance metrics
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    
    // Navigation properties
    public virtual ICollection<ActionPlan> ActionPlans { get; set; } = new List<ActionPlan>();
    public virtual ICollection<LogicalFramework> LogicalFrameworks { get; set; } = new List<LogicalFramework>();
    public virtual ICollection<ProjectAlignment> ProjectAlignments { get; set; } = new List<ProjectAlignment>();
    public virtual ICollection<ProjectRegion> ProjectRegions { get; set; } = new List<ProjectRegion>();
    public virtual ICollection<ProjectSector> ProjectSectors { get; set; } = new List<ProjectSector>();
    public virtual ICollection<ProjectPartner> ProjectPartners { get; set; } = new List<ProjectPartner>();
    public virtual ICollection<ProjectDonor> ProjectDonors { get; set; } = new List<ProjectDonor>();
    public virtual ICollection<ProjectFile> ProjectFiles { get; set; } = new List<ProjectFile>();
}