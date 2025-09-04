using MEPlatform.Core.Entities.Project;
using MEPlatform.Core.Entities.Setup;

namespace MEPlatform.Core.Entities.Associations;

public class ProjectPartner : BaseEntity
{
    public int ProgramId { get; set; }
    public int PartnerId { get; set; }
    
    public virtual Program Program { get; set; } = null!;
    public virtual Partner Partner { get; set; } = null!;
}