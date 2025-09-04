using MEPlatform.Core.Entities.Project;
using MEPlatform.Core.Entities.Setup;

namespace MEPlatform.Core.Entities.Associations;

public class ProjectDonor : BaseEntity
{
    public int ProgramId { get; set; }
    public int DonorId { get; set; }
    
    public virtual Program Program { get; set; } = null!;
    public virtual Donor Donor { get; set; } = null!;
}