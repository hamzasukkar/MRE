using System.ComponentModel.DataAnnotations;

namespace MEPlatform.Web.Models
{
    // Program related models
    public class ProgramSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int ProjectsCount { get; set; }
        public int CompletedProjects { get; set; }
        public int ActiveProjects { get; set; }
        public decimal? OverallProgress { get; set; }
        public decimal? Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Sectors { get; set; } = new();
        public List<string> Regions { get; set; } = new();
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public string Manager { get; set; } = string.Empty;
        public string Donor { get; set; } = string.Empty;
        public int FrameworksCount { get; set; }
    }

    public class CreateProgramViewModel
    {
        [Required(ErrorMessage = "Program name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; } = DateTime.Today.AddYears(1);

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be positive")]
        public decimal? Budget { get; set; }

        [StringLength(100, ErrorMessage = "Manager name cannot be longer than 100 characters")]
        public string Manager { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Donor name cannot be longer than 100 characters")]
        public string Donor { get; set; } = string.Empty;

        public List<string> SelectedSectors { get; set; } = new();
        public List<string> SelectedRegions { get; set; } = new();
    }

    public class EditProgramViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Program name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be positive")]
        public decimal? Budget { get; set; }

        [StringLength(100, ErrorMessage = "Manager name cannot be longer than 100 characters")]
        public string Manager { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Donor name cannot be longer than 100 characters")]
        public string Donor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = "Planning";

        public List<string> SelectedSectors { get; set; } = new();
        public List<string> SelectedRegions { get; set; } = new();

        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }

        public int ProjectsCount { get; set; }
        public int CompletedProjects { get; set; }
        public int ActiveProjects { get; set; }
        public decimal? OverallProgress { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ProgramDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int ProjectsCount { get; set; }
        public int CompletedProjects { get; set; }
        public int ActiveProjects { get; set; }
        public int OnHoldProjects { get; set; }
        public decimal? OverallProgress { get; set; }
        public decimal? Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Sectors { get; set; } = new();
        public List<string> Regions { get; set; } = new();
        
        // Performance metrics
        public decimal Trend { get; set; }
        public decimal Performance { get; set; }
        public decimal FinancialPerformance { get; set; }
        public decimal PhysicalPerformance { get; set; }
        public decimal OtherPerformance { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Manager { get; set; } = string.Empty;
        public string Donor { get; set; } = string.Empty;
        public int FrameworksCount { get; set; }
        
        // Framework and organization info
        public string Framework { get; set; } = string.Empty;
        public string ResponsibleOrganization { get; set; } = string.Empty;
        
        // Beneficiary information
        public int TotalBeneficiaries { get; set; }
        public int DirectBeneficiaries { get; set; }
        public int IndirectBeneficiaries { get; set; }
        
        // Related projects
        public List<ProjectSummary> Projects { get; set; } = new();
    }
}