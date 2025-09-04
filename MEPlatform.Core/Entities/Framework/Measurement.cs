namespace MEPlatform.Core.Entities.Framework;

public class Measurement : BaseEntity
{
    public int IndicatorId { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public string ValueType { get; set; } = "Real"; // "Real" or "Provisional"
    
    public virtual Indicator Indicator { get; set; } = null!;
}