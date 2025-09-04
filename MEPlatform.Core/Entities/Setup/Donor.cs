using MEPlatform.Core.Entities.Associations;

namespace MEPlatform.Core.Entities.Setup;

public class Donor : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<ProjectDonor> ProjectDonors { get; set; } = new List<ProjectDonor>();
}