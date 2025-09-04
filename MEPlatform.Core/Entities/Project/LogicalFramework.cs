namespace MEPlatform.Core.Entities.Project;

public class LogicalFramework : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int ProgramId { get; set; }
    public string Type { get; set; } = "Goal"; // Goal, Outcome, Output
    public decimal Weight { get; set; }
    public string? Risks { get; set; }
    
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    
    public virtual Program Program { get; set; } = null!;
    public virtual ICollection<LogicalFrameworkIndicator> Indicators { get; set; } = new List<LogicalFrameworkIndicator>();
}