namespace MEPlatform.Application.DTOs.Programs;

public class ProjectAlignmentDto
{
    public int Id { get; set; }
    public int ProgramId { get; set; }
    public int? FrameworkId { get; set; }
    public int? FrameworkElementId { get; set; }
    public string? FrameworkName { get; set; }
    public string? FrameworkElementName { get; set; }
}

public class CreateProjectAlignmentDto
{
    public int ProgramId { get; set; }
    public int? FrameworkId { get; set; }
    public int? FrameworkElementId { get; set; }
}