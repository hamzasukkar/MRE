using MEPlatform.Core.Enums;
using MEPlatform.Core.Entities.Associations;

namespace MEPlatform.Core.Entities.Framework;

public class Framework : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public FrameworkType Type { get; set; }
    
    // Auto-calculated performance metrics
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    
    // Navigation properties
    public virtual ICollection<FrameworkElement> Elements { get; set; } = new List<FrameworkElement>();
    public virtual ICollection<ProjectAlignment> ProjectAlignments { get; set; } = new List<ProjectAlignment>();
}