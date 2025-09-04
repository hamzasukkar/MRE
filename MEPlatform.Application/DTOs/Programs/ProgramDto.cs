namespace MEPlatform.Application.DTOs.Programs;

public class ProgramDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Status1 { get; set; } = string.Empty;
    public string Status2 { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal EstimatedBudget { get; set; }
    public decimal RealBudget { get; set; }
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
}

public class ProgramDetailsDto : ProgramDto
{
    public List<ActionPlanDto> ActionPlans { get; set; } = new();
    public List<LogicalFrameworkDto> LogicalFrameworks { get; set; } = new();
    public List<ProjectAlignmentDto> ProjectAlignments { get; set; } = new();
    public List<string> RegionNames { get; set; } = new();
    public List<string> SectorNames { get; set; } = new();
    public List<string> PartnerNames { get; set; } = new();
    public List<string> DonorNames { get; set; } = new();
    public List<ProjectFileDto> ProjectFiles { get; set; } = new();
}

public class CreateProgramDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Status1 { get; set; } = string.Empty;
    public string Status2 { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal EstimatedBudget { get; set; }
    public List<int>? AlignmentIds { get; set; }
    public List<int>? RegionIds { get; set; }
    public List<int>? SectorIds { get; set; }
    public List<int>? PartnerIds { get; set; }
    public List<int>? DonorIds { get; set; }
}

public class UpdateProgramDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Status1 { get; set; } = string.Empty;
    public string Status2 { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal EstimatedBudget { get; set; }
    public decimal RealBudget { get; set; }
}