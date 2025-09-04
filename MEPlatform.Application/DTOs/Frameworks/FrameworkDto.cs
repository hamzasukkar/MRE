using MEPlatform.Core.Enums;

namespace MEPlatform.Application.DTOs.Frameworks;

public class FrameworkDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public FrameworkType Type { get; set; }
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
}

public class FrameworkDetailsDto : FrameworkDto
{
    public List<FrameworkElementDto> Elements { get; set; } = new();
}

public class CreateFrameworkDto
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
    public FrameworkType Type { get; set; }
}

public class UpdateFrameworkDto
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Weight { get; set; }
}