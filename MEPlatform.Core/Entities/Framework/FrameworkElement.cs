using MEPlatform.Core.Enums;
using MEPlatform.Core.Entities.Associations;

namespace MEPlatform.Core.Entities.Framework;

public class FrameworkElement : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public ElementType Type { get; set; }
    public int FrameworkId { get; set; }
    public int? ParentId { get; set; }
    public string? Description { get; set; }
    
    // Performance metrics (auto-calculated)
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    
    // Navigation properties
    public virtual Framework Framework { get; set; } = null!;
    public virtual FrameworkElement? Parent { get; set; }
    public virtual ICollection<FrameworkElement> Children { get; set; } = new List<FrameworkElement>();
    public virtual ICollection<Indicator> Indicators { get; set; } = new List<Indicator>();
    public virtual ICollection<ProjectAlignment> ProjectAlignments { get; set; } = new List<ProjectAlignment>();
}