namespace MEPlatform.Application.DTOs.Frameworks;

public class IndicatorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public int? FrameworkElementId { get; set; }
    public string? Source { get; set; }
    public string? Unit { get; set; }
    public string? IndicatorImpact { get; set; }
    public string? Atif { get; set; }
    public string? Concept { get; set; }
    public string? Description { get; set; }
    public string? MethodOfComputation { get; set; }
    public string? Comment { get; set; }
    public decimal? Target { get; set; }
    public int? TargetYear { get; set; }
    public decimal? GAGRA { get; set; }
    public decimal? GAGRR { get; set; }
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public string? ParentType { get; set; }
    public List<MeasurementDto> Measurements { get; set; } = new();
}

public class CreateIndicatorDto
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public int? FrameworkElementId { get; set; }
    public string? Source { get; set; }
    public string? Unit { get; set; }
    public string? IndicatorImpact { get; set; }
    public string? Atif { get; set; }
    public string? Concept { get; set; }
    public string? Description { get; set; }
    public string? MethodOfComputation { get; set; }
    public string? Comment { get; set; }
    public string? ParentType { get; set; }
}

public class UpdateIndicatorDto
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public string? Source { get; set; }
    public string? Unit { get; set; }
    public string? IndicatorImpact { get; set; }
    public string? Atif { get; set; }
    public string? Concept { get; set; }
    public string? Description { get; set; }
    public string? MethodOfComputation { get; set; }
    public string? Comment { get; set; }
}