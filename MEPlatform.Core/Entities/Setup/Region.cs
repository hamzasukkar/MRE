using MEPlatform.Core.Entities.Associations;

namespace MEPlatform.Core.Entities.Setup;

public class Region : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int? ParentId { get; set; }
    public string Type { get; set; } = "Region"; // Region, Province, District, Community
    
    public virtual Region? Parent { get; set; }
    public virtual ICollection<Region> Children { get; set; } = new List<Region>();
    public virtual ICollection<ProjectRegion> ProjectRegions { get; set; } = new List<ProjectRegion>();
}