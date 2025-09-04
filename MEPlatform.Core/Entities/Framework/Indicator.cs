namespace MEPlatform.Core.Entities.Framework;

public class Indicator : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public int? FrameworkElementId { get; set; }
    public string? Source { get; set; }
    public string? Unit { get; set; }
    public string? IndicatorImpact { get; set; } // + or -
    public string? Atif { get; set; }
    public string? Concept { get; set; }
    public string? Description { get; set; }
    public string? MethodOfComputation { get; set; }
    public string? Comment { get; set; }
    
    // Auto-calculated fields
    public decimal? Target { get; set; }
    public int? TargetYear { get; set; }
    public decimal? GAGRA { get; set; }
    public decimal? GAGRR { get; set; }
    public decimal Trend { get; set; }
    
    // Performance metrics
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    
    // For SNDV/PF indicators
    public string? ParentType { get; set; } // "SubOutput" or "Output"
    
    // Navigation properties
    public virtual FrameworkElement? FrameworkElement { get; set; }
    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
}