namespace MEPlatform.Core.Entities.Project;

public class ActionPlan : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int ProgramId { get; set; }
    public decimal EstimatedBudget { get; set; }
    public decimal RealBudget { get; set; }
    
    public virtual Program Program { get; set; } = null!;
    public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();
}