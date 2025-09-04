using MEPlatform.Core.Entities.Framework;
using MEPlatform.Core.Entities.Project;

namespace MEPlatform.Core.Entities.Associations;

public class ProjectAlignment : BaseEntity
{
    public int ProgramId { get; set; }
    public int? FrameworkId { get; set; }
    public int? FrameworkElementId { get; set; }
    
    public virtual Program Program { get; set; } = null!;
    public virtual Framework.Framework? Framework { get; set; }
    public virtual FrameworkElement? FrameworkElement { get; set; }
}