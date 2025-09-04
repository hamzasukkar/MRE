namespace MEPlatform.Application.DTOs.Programs;

public class ActionPlanDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProgramId { get; set; }
    public decimal EstimatedBudget { get; set; }
    public decimal RealBudget { get; set; }
    public List<DimensionDto> Dimensions { get; set; } = new();
}

public class CreateActionPlanDto
{
    public string Name { get; set; } = string.Empty;
    public int ProgramId { get; set; }
    public decimal EstimatedBudget { get; set; }
    public decimal RealBudget { get; set; }
}

public class UpdateActionPlanDto
{
    public string Name { get; set; } = string.Empty;
    public decimal EstimatedBudget { get; set; }
    public decimal RealBudget { get; set; }
}