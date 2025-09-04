namespace MEPlatform.Application.DTOs.Monitoring;

public class MonitoringFrameworkDto
{
    public List<FrameworkMonitoringCardDto> Frameworks { get; set; } = new();
}

public class FrameworkMonitoringCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal Trend { get; set; }
    public int OutcomesCount { get; set; }
    public int GoalsCount { get; set; }
    public int OutputsCount { get; set; }
    public int TargetsCount { get; set; }
    public int SubOutputsCount { get; set; }
    public int IndicatorsCount { get; set; }
    public int ProgramsCount { get; set; }
}

public class MonitoringKanbanCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal Trend { get; set; }
    public string Type { get; set; } = string.Empty;
    public Dictionary<string, int> Navigation { get; set; } = new();
    public Dictionary<string, object> AdditionalInfo { get; set; } = new();
    public Dictionary<string, object> ChartData { get; set; } = new();
}

public class MonitoringPartnersDto
{
    public List<PartnerMonitoringCardDto> Partners { get; set; } = new();
    public List<SectorMonitoringCardDto> Sectors { get; set; } = new();
    public List<DonorMonitoringCardDto> Donors { get; set; } = new();
}

public class PartnerMonitoringCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
}

public class SectorMonitoringCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
}

public class DonorMonitoringCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
}

public class MonitoringRegionalDto
{
    public List<RegionMonitoringCardDto> Regions { get; set; } = new();
    public List<ProvinceMonitoringCardDto> Provinces { get; set; } = new();
    public List<DistrictMonitoringCardDto> Districts { get; set; } = new();
    public List<CommunityMonitoringCardDto> Communities { get; set; } = new();
}

public class RegionMonitoringCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
}

public class ProvinceMonitoringCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
}

public class DistrictMonitoringCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
}

public class CommunityMonitoringCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
}

public class MonitoringProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Status1 { get; set; } = string.Empty;
    public decimal EstimatedBudget { get; set; }
    public decimal RealBudget { get; set; }
    public decimal Performance { get; set; }
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public string RegionName { get; set; } = string.Empty;
}

public class DashboardDto
{
    public int TotalPrograms { get; set; }
    public int TotalIndicators { get; set; }
    public List<RegionProgramDto> ProgramsByRegion { get; set; } = new();
    public List<IndicatorTrendDto> IndicatorTrends { get; set; } = new();
}

public class RegionProgramDto
{
    public string RegionName { get; set; } = string.Empty;
    public int ProgramsCount { get; set; }
    public decimal TotalBudget { get; set; }
    public decimal Performance { get; set; }
}

public class IndicatorTrendDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Trend { get; set; }
    public decimal Performance { get; set; }
    public Dictionary<string, object> ChartData { get; set; } = new();
}

// Additional DTOs needed by Web services
public class FrameworkPerformanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Progress { get; set; }
    public int TotalProjects { get; set; }
    public int CompletedProjects { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; }
}

public class PartnerPerformanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
    public decimal TotalBudget { get; set; }
}

public class SectorPerformanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
    public decimal TotalBudget { get; set; }
}

public class DonorPerformanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
    public decimal TotalFunding { get; set; }
}

public class RegionalPerformanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal FinancialPerformance { get; set; }
    public decimal PhysicalPerformance { get; set; }
    public decimal OtherPerformance { get; set; }
    public int ProjectsCount { get; set; }
    public int Population { get; set; }
}

public class ProjectMonitoringDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Framework { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Progress { get; set; }
    public string Region { get; set; } = string.Empty;
    public string Sector { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
}

public class ProjectKanbanDto
{
    public string ViewType { get; set; } = string.Empty;
    public Dictionary<string, List<ProjectKanbanCardDto>> Columns { get; set; } = new();
}

public class ProjectKanbanCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Progress { get; set; }
    public string Priority { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public List<string> Tags { get; set; } = new();
}