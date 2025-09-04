namespace MEPlatform.Application.DTOs.Programs;

public class DimensionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ActionPlanId { get; set; }
    public string Type { get; set; } = "Financial";
    public DateTime Date { get; set; }
    public decimal PlannedValue { get; set; }
    public decimal RealizedValue { get; set; }
}

public class CreateDimensionDto
{
    public string Name { get; set; } = string.Empty;
    public int ActionPlanId { get; set; }
    public string Type { get; set; } = "Financial";
    public DateTime Date { get; set; }
    public decimal PlannedValue { get; set; }
    public decimal RealizedValue { get; set; }
}

public class UpdateDimensionDto
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = "Financial";
    public DateTime Date { get; set; }
    public decimal PlannedValue { get; set; }
    public decimal RealizedValue { get; set; }
}