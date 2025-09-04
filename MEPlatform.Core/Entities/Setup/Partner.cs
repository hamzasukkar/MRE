using MEPlatform.Core.Entities.Associations;

namespace MEPlatform.Core.Entities.Setup;

public class Partner : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<ProjectPartner> ProjectPartners { get; set; } = new List<ProjectPartner>();
}