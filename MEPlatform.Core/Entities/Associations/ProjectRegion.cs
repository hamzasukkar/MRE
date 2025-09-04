using MEPlatform.Core.Entities.Project;
using MEPlatform.Core.Entities.Setup;

namespace MEPlatform.Core.Entities.Associations;

public class ProjectRegion : BaseEntity
{
    public int ProgramId { get; set; }
    public int RegionId { get; set; }
    
    public virtual Program Program { get; set; } = null!;
    public virtual Region Region { get; set; } = null!;
}