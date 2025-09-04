namespace MEPlatform.Core.Entities.Project;

public class LogicalFrameworkIndicator : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int LogicalFrameworkId { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public decimal Target { get; set; }
    public decimal Actual { get; set; }
    
    public virtual LogicalFramework LogicalFramework { get; set; } = null!;
}