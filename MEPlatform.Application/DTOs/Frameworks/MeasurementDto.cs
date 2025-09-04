namespace MEPlatform.Application.DTOs.Frameworks;

public class MeasurementDto
{
    public int Id { get; set; }
    public int IndicatorId { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public string ValueType { get; set; } = "Real";
}

public class CreateMeasurementDto
{
    public int IndicatorId { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public string ValueType { get; set; } = "Real";
}

public class UpdateMeasurementDto
{
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public string ValueType { get; set; } = "Real";
}