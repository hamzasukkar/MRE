using System.ComponentModel.DataAnnotations;

namespace MEPlatform.Web.Models
{
    // Measure related models
    public class MeasureSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string MeasureType { get; set; } = string.Empty; // Quantitative, Qualitative, Binary
        public string DataSource { get; set; } = string.Empty;
        public string CollectionMethod { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty; // Monthly, Quarterly, Annually
        public decimal? Target { get; set; }
        public decimal? CurrentValue { get; set; }
        public decimal? BaselineValue { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Related entities
        public int IndicatorId { get; set; }
        public string IndicatorName { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        
        // Performance metrics
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal Trend { get; set; }
        public decimal Achievement { get; set; } // Percentage of target achieved
        
        // Data quality indicators
        public string DataQuality { get; set; } = string.Empty; // High, Medium, Low
        public bool IsVerified { get; set; }
        public string ResponsiblePerson { get; set; } = string.Empty;
    }

    public class CreateMeasureViewModel
    {
        [Required(ErrorMessage = "Measure name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Unit is required")]
        [StringLength(50, ErrorMessage = "Unit cannot be longer than 50 characters")]
        public string Unit { get; set; } = string.Empty;

        [Required(ErrorMessage = "Measure type is required")]
        public string MeasureType { get; set; } = "Quantitative";

        [Required(ErrorMessage = "Data source is required")]
        [StringLength(200, ErrorMessage = "Data source cannot be longer than 200 characters")]
        public string DataSource { get; set; } = string.Empty;

        [Required(ErrorMessage = "Collection method is required")]
        [StringLength(200, ErrorMessage = "Collection method cannot be longer than 200 characters")]
        public string CollectionMethod { get; set; } = string.Empty;

        [Required(ErrorMessage = "Frequency is required")]
        public string Frequency { get; set; } = "Monthly";

        [Range(0, double.MaxValue, ErrorMessage = "Target must be positive")]
        public decimal? Target { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Baseline value must be positive")]
        public decimal? BaselineValue { get; set; }

        [Required(ErrorMessage = "Indicator is required")]
        public int IndicatorId { get; set; }

        [Required(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }

        [StringLength(100, ErrorMessage = "Responsible person name cannot be longer than 100 characters")]
        public string ResponsiblePerson { get; set; } = string.Empty;

        public string Status { get; set; } = "Active";
    }

    public class EditMeasureViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Measure name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Unit is required")]
        [StringLength(50, ErrorMessage = "Unit cannot be longer than 50 characters")]
        public string Unit { get; set; } = string.Empty;

        [Required(ErrorMessage = "Measure type is required")]
        public string MeasureType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data source is required")]
        [StringLength(200, ErrorMessage = "Data source cannot be longer than 200 characters")]
        public string DataSource { get; set; } = string.Empty;

        [Required(ErrorMessage = "Collection method is required")]
        [StringLength(200, ErrorMessage = "Collection method cannot be longer than 200 characters")]
        public string CollectionMethod { get; set; } = string.Empty;

        [Required(ErrorMessage = "Frequency is required")]
        public string Frequency { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Target must be positive")]
        public decimal? Target { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Current value must be positive")]
        public decimal? CurrentValue { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Baseline value must be positive")]
        public decimal? BaselineValue { get; set; }

        [Required(ErrorMessage = "Indicator is required")]
        public int IndicatorId { get; set; }

        [Required(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }

        [StringLength(100, ErrorMessage = "Responsible person name cannot be longer than 100 characters")]
        public string ResponsiblePerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = string.Empty;

        // Performance metrics
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal Trend { get; set; }
        public decimal Achievement { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string DataQuality { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
    }

    public class MeasureDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string MeasureType { get; set; } = string.Empty;
        public string DataSource { get; set; } = string.Empty;
        public string CollectionMethod { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public decimal? Target { get; set; }
        public decimal? CurrentValue { get; set; }
        public decimal? BaselineValue { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Related entities
        public int IndicatorId { get; set; }
        public string IndicatorName { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        
        // Performance metrics
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal Trend { get; set; }
        public decimal Achievement { get; set; }
        
        // Data quality and verification
        public string DataQuality { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public string ResponsiblePerson { get; set; } = string.Empty;
        
        // Historical data
        public List<MeasureDataPoint> HistoricalData { get; set; } = new();
        
        // Related project and framework info
        public string Framework { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
    }

    public class MeasureDataPoint
    {
        public int Id { get; set; }
        public int MeasureId { get; set; }
        public decimal Value { get; set; }
        public DateTime RecordedDate { get; set; }
        public string Note { get; set; } = string.Empty;
        public string RecordedBy { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public string VerificationSource { get; set; } = string.Empty;
        public decimal? PerformanceScore { get; set; }
    }

    public class MeasureStatistics
    {
        public int TotalMeasures { get; set; }
        public int ActiveMeasures { get; set; }
        public int CompletedMeasures { get; set; }
        public int OverdueMeasures { get; set; }
        public decimal AverageAchievement { get; set; }
        public decimal AverageFinancialPerformance { get; set; }
        public decimal AveragePhysicalPerformance { get; set; }
        public int HighPerformingMeasures { get; set; }
        public int LowPerformingMeasures { get; set; }
        public int VerifiedMeasures { get; set; }
        public int UnverifiedMeasures { get; set; }
    }
}