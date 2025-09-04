using MEPlatform.Core.Entities.Project;
using MEPlatform.Core.Entities.Setup;

namespace MEPlatform.Core.Entities.Associations;

public class ProjectSector : BaseEntity
{
    public int ProgramId { get; set; }
    public int SectorId { get; set; }
    
    public virtual Program Program { get; set; } = null!;
    public virtual Sector Sector { get; set; } = null!;
}