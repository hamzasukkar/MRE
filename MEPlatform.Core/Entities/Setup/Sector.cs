using MEPlatform.Core.Entities.Associations;

namespace MEPlatform.Core.Entities.Setup;

public class Sector : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<ProjectSector> ProjectSectors { get; set; } = new List<ProjectSector>();
}