using MEPlatform.Core.Enums;

namespace MEPlatform.Application.DTOs.Frameworks;

public class FrameworkElementDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public ElementType Type { get; set; }
    public int FrameworkId { get; set; }
    public int? ParentId { get; set; }
    public string? Description { get; set; }
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public List<FrameworkElementDto> Children { get; set; } = new();
    public List<IndicatorDto> Indicators { get; set; } = new();
}

public class CreateFrameworkElementDto
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public ElementType Type { get; set; }
    public int FrameworkId { get; set; }
    public int? ParentId { get; set; }
    public string? Description { get; set; }
}

public class UpdateFrameworkElementDto
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public string? Description { get; set; }
}