using MEPlatform.Core.Entities.Framework;

namespace MEPlatform.Core.Entities.Setup;

public class Unit : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Indicator> Indicators { get; set; } = new List<Indicator>();
}