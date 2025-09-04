namespace MEPlatform.Application.DTOs.Programs;

public class LogicalFrameworkDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProgramId { get; set; }
    public string Type { get; set; } = "Goal";
    public decimal Weight { get; set; }
    public string? Risks { get; set; }
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public List<LogicalFrameworkIndicatorDto> Indicators { get; set; } = new();
}

public class CreateLogicalFrameworkDto
{
    public string Name { get; set; } = string.Empty;
    public int ProgramId { get; set; }
    public string Type { get; set; } = "Goal";
    public decimal Weight { get; set; }
    public string? Risks { get; set; }
}

public class UpdateLogicalFrameworkDto
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = "Goal";
    public decimal Weight { get; set; }
    public string? Risks { get; set; }
}