namespace MEPlatform.Application.DTOs.Programs;

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int ProgramId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public decimal Progress { get; set; }
    public List<string> Regions { get; set; } = new();
    public List<string> Sectors { get; set; } = new();
    public List<string> Partners { get; set; } = new();
    public List<string> Donors { get; set; } = new();
}

public class CreateProjectDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int ProgramId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public List<int>? RegionIds { get; set; }
    public List<int>? SectorIds { get; set; }
    public List<int>? PartnerIds { get; set; }
    public List<int>? DonorIds { get; set; }
}

public class UpdateProjectDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public decimal Progress { get; set; }
    public List<int>? RegionIds { get; set; }
    public List<int>? SectorIds { get; set; }
    public List<int>? PartnerIds { get; set; }
    public List<int>? DonorIds { get; set; }
}