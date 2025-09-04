namespace MEPlatform.Application.DTOs.Programs;

public class LogicalFrameworkIndicatorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int LogicalFrameworkId { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public decimal Target { get; set; }
    public decimal Actual { get; set; }
}

public class CreateLogicalFrameworkIndicatorDto
{
    public string Name { get; set; } = string.Empty;
    public int LogicalFrameworkId { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public decimal Target { get; set; }
}

public class UpdateLogicalFrameworkIndicatorDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public decimal Target { get; set; }
    public decimal Actual { get; set; }
}