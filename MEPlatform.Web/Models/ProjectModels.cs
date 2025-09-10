using System.ComponentModel.DataAnnotations;

namespace MEPlatform.Web.Models
{
    // Project related models
    public class ProjectSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Progress { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Framework { get; set; } = string.Empty;
        public int? ProgramId { get; set; }
        public string? ProgramName { get; set; }
        public decimal? Budget { get; set; }
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public string Manager { get; set; } = string.Empty;
        public int IndicatorsCount { get; set; }
        public int MeasurementsCount { get; set; }
    }

    public class ProjectMonitoringItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Framework { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Progress { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        // Additional monitoring properties
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal Trend { get; set; }
    }

    public class CreateProjectViewModel
    {
        [Required(ErrorMessage = "Project name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; } = DateTime.Today.AddYears(1);

        [Required(ErrorMessage = "Region is required")]
        [StringLength(100, ErrorMessage = "Region name cannot be longer than 100 characters")]
        public string Region { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sector is required")]
        [StringLength(100, ErrorMessage = "Sector name cannot be longer than 100 characters")]
        public string Sector { get; set; } = string.Empty;

        [Required(ErrorMessage = "Framework is required")]
        public string Framework { get; set; } = string.Empty;

        public int? ProgramId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be positive")]
        public decimal? Budget { get; set; }

        [StringLength(100, ErrorMessage = "Manager name cannot be longer than 100 characters")]
        public string Manager { get; set; } = string.Empty;
    }

    public class EditProjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Project name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Region is required")]
        [StringLength(100, ErrorMessage = "Region name cannot be longer than 100 characters")]
        public string Region { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sector is required")]
        [StringLength(100, ErrorMessage = "Sector name cannot be longer than 100 characters")]
        public string Sector { get; set; } = string.Empty;

        [Required(ErrorMessage = "Framework is required")]
        public string Framework { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = "Planning";

        public int? ProgramId { get; set; }
        public string? ProgramName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be positive")]
        public decimal? Budget { get; set; }

        [StringLength(100, ErrorMessage = "Manager name cannot be longer than 100 characters")]
        public string Manager { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "Progress must be between 0 and 100")]
        public decimal Progress { get; set; }

        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }

        public DateTime CreatedAt { get; set; }
        public int IndicatorsCount { get; set; }
        public int MeasurementsCount { get; set; }
    }

    public class ProjectDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Progress { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Framework { get; set; } = string.Empty;
        public int? ProgramId { get; set; }
        public string? ProgramName { get; set; }
        public decimal? Budget { get; set; }
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public string Manager { get; set; } = string.Empty;
        public int IndicatorsCount { get; set; }
        public int MeasurementsCount { get; set; }
        
        // Framework alignment
        public List<ElementSummary> AlignedElements { get; set; } = new();
        public List<IndicatorSummary> TrackedIndicators { get; set; } = new();
    }
}