namespace MEPlatform.Core.Entities.Project;

public class ProjectFile : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public int ProgramId { get; set; }
    
    public virtual Program Program { get; set; } = null!;
}