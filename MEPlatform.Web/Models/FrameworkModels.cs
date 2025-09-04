using System.ComponentModel.DataAnnotations;

namespace MEPlatform.Web.Models
{
    // Framework related models
    public class FrameworkSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int ElementsCount { get; set; }
        public int IndicatorsCount { get; set; }
        public int ProjectsCount { get; set; }
        public decimal? OverallProgress { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> TopLevelElements { get; set; } = new();
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
    }

    // Element related models
    public class ElementSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int FrameworkId { get; set; }
        public int? ParentId { get; set; }
        public decimal Weight { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
    }

    public class CreateElementViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string? Description { get; set; }

        [Range(0, 100, ErrorMessage = "Weight must be between 0 and 100")]
        public decimal Weight { get; set; } = 100m;

        [StringLength(50, ErrorMessage = "Icon name cannot be longer than 50 characters")]
        public string? Icon { get; set; }

        public int? ParentId { get; set; }
    }

    public class EditElementViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string? Description { get; set; }

        [Range(0, 100, ErrorMessage = "Weight must be between 0 and 100")]
        public decimal Weight { get; set; }

        [StringLength(50, ErrorMessage = "Icon name cannot be longer than 50 characters")]
        public string? Icon { get; set; }

        public string Type { get; set; } = string.Empty;
        public int FrameworkId { get; set; }
        public int? ParentId { get; set; }
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
        
        public int ChildrenCount { get; set; }
        public int IndicatorsCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // Indicator related models
    public class IndicatorSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ElementId { get; set; }
        public string? Unit { get; set; }
        public decimal? Target { get; set; }
        public decimal? CurrentValue { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MeasurementsCount { get; set; }
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
        
        // Additional indicator properties from core entity
        public decimal? GAGRA { get; set; }
        public decimal? GAGRR { get; set; }
        public string? Source { get; set; }
        public string? IndicatorImpact { get; set; }
        public int? TargetYear { get; set; }
    }

    public class CreateIndicatorViewModel
    {
        [Required(ErrorMessage = "Indicator name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string? Description { get; set; }

        [StringLength(20, ErrorMessage = "Unit cannot be longer than 20 characters")]
        public string? Unit { get; set; }

        public decimal? Target { get; set; }

        public decimal? Baseline { get; set; }

        [StringLength(50, ErrorMessage = "Measurement frequency cannot be longer than 50 characters")]
        public string? MeasurementFrequency { get; set; }

        [StringLength(200, ErrorMessage = "Data source cannot be longer than 200 characters")]
        public string? DataSource { get; set; }

        [StringLength(100, ErrorMessage = "Responsible party cannot be longer than 100 characters")]
        public string? ResponsibleParty { get; set; }
    }

    public class EditIndicatorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Indicator name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string? Description { get; set; }

        [StringLength(20, ErrorMessage = "Unit cannot be longer than 20 characters")]
        public string? Unit { get; set; }

        public decimal? Target { get; set; }

        public decimal? Baseline { get; set; }

        public decimal? CurrentValue { get; set; }

        [StringLength(50, ErrorMessage = "Measurement frequency cannot be longer than 50 characters")]
        public string? MeasurementFrequency { get; set; }

        [StringLength(200, ErrorMessage = "Data source cannot be longer than 200 characters")]
        public string? DataSource { get; set; }

        [StringLength(100, ErrorMessage = "Responsible party cannot be longer than 100 characters")]
        public string? ResponsibleParty { get; set; }

        public int ElementId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MeasurementsCount { get; set; }
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
    }

    public class IndicatorDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ElementId { get; set; }
        public string? Unit { get; set; }
        public decimal? Target { get; set; }
        public decimal? CurrentValue { get; set; }
        public decimal? Baseline { get; set; }
        public string? Description { get; set; }
        public string? MeasurementFrequency { get; set; }
        public string? DataSource { get; set; }
        public string? ResponsibleParty { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MeasurementsCount { get; set; }
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
        
        // Additional properties from core entity
        public decimal? GAGRA { get; set; }
        public decimal? GAGRR { get; set; }
        public string? Source { get; set; }
        public string? IndicatorImpact { get; set; }
        public int? TargetYear { get; set; }
    }

    // Statistics models
    public class FrameworkStatistics
    {
        public int OutcomesCount { get; set; }
        public int OutputsCount { get; set; }
        public int SubOutputsCount { get; set; }
        public int IndicatorsCount { get; set; }
        public int MeasurementsCount { get; set; }
        public decimal OverallProgress { get; set; }
    }
}