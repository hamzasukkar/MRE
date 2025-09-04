namespace MEPlatform.Core.Entities.Project;

public class Dimension : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int ActionPlanId { get; set; }
    public string Type { get; set; } = "Financial"; // Financial, Physical, Others
    public DateTime Date { get; set; }
    public decimal PlannedValue { get; set; }
    public decimal RealizedValue { get; set; }
    
    public virtual ActionPlan ActionPlan { get; set; } = null!;
}