using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Measures
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<MeasureSummary> Measures { get; set; } = new();
        public MeasureStatistics Statistics { get; set; } = new();
        public List<string> Projects { get; set; } = new();
        public List<string> Indicators { get; set; } = new();
        public List<string> MeasureTypes { get; set; } = new();
        public List<string> Frequencies { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ProjectFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? IndicatorFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TypeFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FrequencyFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? StatusFilter { get; set; }

        public async Task OnGetAsync()
        {
            LoadFilterOptions();
            LoadStatistics();
            LoadMeasures();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                TempData["SuccessMessage"] = "Measure deleted successfully.";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Failed to delete measure.";
                return RedirectToPage("./Index");
            }
        }

        private void LoadFilterOptions()
        {
            Projects = new List<string>
            {
                "Syrian Healthcare Infrastructure Recovery",
                "Education System Restoration Program",
                "Emergency Water Supply Project",
                "Community Health Centers Rehabilitation",
                "Teacher Training Initiative",
                "Rural Healthcare Access Program"
            };

            Indicators = new List<string>
            {
                "Healthcare facilities restored",
                "Healthcare staff trained",
                "Schools rebuilt",
                "Students enrolled",
                "Water systems operational",
                "Communities served",
                "Medical equipment installed",
                "Teacher certification rates"
            };

            MeasureTypes = new List<string> { "Quantitative", "Qualitative", "Binary" };
            Frequencies = new List<string> { "Weekly", "Monthly", "Quarterly", "Semi-annually", "Annually" };
        }

        private void LoadStatistics()
        {
            Statistics = new MeasureStatistics
            {
                TotalMeasures = 156,
                ActiveMeasures = 98,
                CompletedMeasures = 45,
                OverdueMeasures = 13,
                AverageAchievement = 78.5m,
                AverageFinancialPerformance = 82.3m,
                AveragePhysicalPerformance = 74.7m,
                HighPerformingMeasures = 89,
                LowPerformingMeasures = 23,
                VerifiedMeasures = 134,
                UnverifiedMeasures = 22
            };
        }

        private void LoadMeasures()
        {
            var allMeasures = GetMockMeasures();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                allMeasures = allMeasures.Where(m => 
                    m.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                    m.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                    m.ProjectName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                    m.IndicatorName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(ProjectFilter))
            {
                allMeasures = allMeasures.Where(m => m.ProjectName == ProjectFilter).ToList();
            }

            if (!string.IsNullOrEmpty(IndicatorFilter))
            {
                allMeasures = allMeasures.Where(m => m.IndicatorName == IndicatorFilter).ToList();
            }

            if (!string.IsNullOrEmpty(TypeFilter))
            {
                allMeasures = allMeasures.Where(m => m.MeasureType == TypeFilter).ToList();
            }

            if (!string.IsNullOrEmpty(FrequencyFilter))
            {
                allMeasures = allMeasures.Where(m => m.Frequency == FrequencyFilter).ToList();
            }

            if (!string.IsNullOrEmpty(StatusFilter))
            {
                allMeasures = allMeasures.Where(m => m.Status == StatusFilter).ToList();
            }

            Measures = allMeasures;
        }

        private List<MeasureSummary> GetMockMeasures()
        {
            return new List<MeasureSummary>
            {
                new()
                {
                    Id = 1,
                    Name = "Number of primary healthcare centers operational",
                    Description = "Tracks the count of fully operational primary healthcare centers serving communities",
                    Unit = "facilities",
                    MeasureType = "Quantitative",
                    DataSource = "Ministry of Health Records",
                    CollectionMethod = "Field verification and reporting",
                    Frequency = "Monthly",
                    Target = 25,
                    CurrentValue = 19,
                    BaselineValue = 8,
                    LastUpdated = DateTime.Now.AddDays(-5),
                    CreatedAt = new DateTime(2024, 1, 15),
                    IndicatorId = 1,
                    IndicatorName = "Healthcare facilities restored",
                    ProjectId = 1,
                    ProjectName = "Syrian Healthcare Infrastructure Recovery",
                    Status = "Active",
                    FinancialPerformance = 78.2m,
                    PhysicalPerformance = 76.0m,
                    Trend = 3.1m,
                    Achievement = 76.0m,
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Dr. Ahmad Hassan"
                },
                new()
                {
                    Id = 2,
                    Name = "Healthcare professionals trained and certified",
                    Description = "Number of healthcare workers who completed training programs and received certification",
                    Unit = "persons",
                    MeasureType = "Quantitative",
                    DataSource = "Training Department Records",
                    CollectionMethod = "Training completion certificates",
                    Frequency = "Quarterly",
                    Target = 500,
                    CurrentValue = 412,
                    BaselineValue = 150,
                    LastUpdated = DateTime.Now.AddDays(-12),
                    CreatedAt = new DateTime(2024, 1, 20),
                    IndicatorId = 2,
                    IndicatorName = "Healthcare staff trained",
                    ProjectId = 1,
                    ProjectName = "Syrian Healthcare Infrastructure Recovery",
                    Status = "Active",
                    FinancialPerformance = 85.1m,
                    PhysicalPerformance = 82.4m,
                    Trend = 4.2m,
                    Achievement = 82.4m,
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Dr. Fatima Al-Zahra"
                },
                new()
                {
                    Id = 3,
                    Name = "Schools fully reconstructed and operational",
                    Description = "Number of school buildings that have been completely rebuilt and are operational",
                    Unit = "schools",
                    MeasureType = "Quantitative",
                    DataSource = "Ministry of Education",
                    CollectionMethod = "Engineering assessments and enrollment data",
                    Frequency = "Monthly",
                    Target = 45,
                    CurrentValue = 22,
                    BaselineValue = 5,
                    LastUpdated = DateTime.Now.AddDays(-8),
                    CreatedAt = new DateTime(2024, 2, 1),
                    IndicatorId = 3,
                    IndicatorName = "Schools rebuilt",
                    ProjectId = 2,
                    ProjectName = "Education System Restoration Program",
                    Status = "Active",
                    FinancialPerformance = 52.3m,
                    PhysicalPerformance = 48.9m,
                    Trend = 2.1m,
                    Achievement = 48.9m,
                    DataQuality = "Medium",
                    IsVerified = true,
                    ResponsiblePerson = "Eng. Omar Khalil"
                },
                new()
                {
                    Id = 4,
                    Name = "Student enrollment in restored schools",
                    Description = "Total number of students enrolled in schools that have been restored through the program",
                    Unit = "students",
                    MeasureType = "Quantitative",
                    DataSource = "School enrollment records",
                    CollectionMethod = "Monthly enrollment reports",
                    Frequency = "Monthly",
                    Target = 25000,
                    CurrentValue = 18750,
                    BaselineValue = 8500,
                    LastUpdated = DateTime.Now.AddDays(-3),
                    CreatedAt = new DateTime(2024, 2, 15),
                    IndicatorId = 4,
                    IndicatorName = "Students enrolled",
                    ProjectId = 2,
                    ProjectName = "Education System Restoration Program",
                    Status = "Active",
                    FinancialPerformance = 77.8m,
                    PhysicalPerformance = 75.0m,
                    Trend = 3.5m,
                    Achievement = 75.0m,
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Ms. Layla Mansour"
                },
                new()
                {
                    Id = 5,
                    Name = "Water systems functionality assessment",
                    Description = "Qualitative assessment of water system reliability and quality in target communities",
                    Unit = "assessment score",
                    MeasureType = "Qualitative",
                    DataSource = "Field assessments",
                    CollectionMethod = "Technical evaluation and community feedback",
                    Frequency = "Quarterly",
                    Target = 85,
                    CurrentValue = 72,
                    BaselineValue = 35,
                    LastUpdated = DateTime.Now.AddDays(-18),
                    CreatedAt = new DateTime(2024, 3, 1),
                    IndicatorId = 5,
                    IndicatorName = "Water systems operational",
                    ProjectId = 3,
                    ProjectName = "Emergency Water Supply Project",
                    Status = "Active",
                    FinancialPerformance = 68.5m,
                    PhysicalPerformance = 72.0m,
                    Trend = 1.8m,
                    Achievement = 84.7m,
                    DataQuality = "Medium",
                    IsVerified = false,
                    ResponsiblePerson = "Eng. Youssef Habib"
                },
                new()
                {
                    Id = 6,
                    Name = "Medical equipment installation completion",
                    Description = "Binary measure tracking completion of medical equipment installation at each facility",
                    Unit = "completed/total",
                    MeasureType = "Binary",
                    DataSource = "Installation reports",
                    CollectionMethod = "Installation completion certificates",
                    Frequency = "Weekly",
                    Target = 100,
                    CurrentValue = 78,
                    BaselineValue = 0,
                    LastUpdated = DateTime.Now.AddDays(-2),
                    CreatedAt = new DateTime(2024, 3, 15),
                    IndicatorId = 6,
                    IndicatorName = "Medical equipment installed",
                    ProjectId = 1,
                    ProjectName = "Syrian Healthcare Infrastructure Recovery",
                    Status = "Active",
                    FinancialPerformance = 82.1m,
                    PhysicalPerformance = 78.0m,
                    Trend = 2.5m,
                    Achievement = 78.0m,
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Eng. Samir Khoury"
                },
                new()
                {
                    Id = 7,
                    Name = "Teacher certification program completion rate",
                    Description = "Percentage of teachers completing certification requirements within specified timeframe",
                    Unit = "percentage",
                    MeasureType = "Quantitative",
                    DataSource = "Training institute records",
                    CollectionMethod = "Certification tracking system",
                    Frequency = "Monthly",
                    Target = 90,
                    CurrentValue = 73,
                    BaselineValue = 45,
                    LastUpdated = DateTime.Now.AddDays(-7),
                    CreatedAt = new DateTime(2024, 4, 1),
                    IndicatorId = 7,
                    IndicatorName = "Teacher certification rates",
                    ProjectId = 2,
                    ProjectName = "Education System Restoration Program",
                    Status = "Active",
                    FinancialPerformance = 75.2m,
                    PhysicalPerformance = 81.1m,
                    Trend = 2.9m,
                    Achievement = 81.1m,
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Dr. Nadia Salim"
                },
                new()
                {
                    Id = 8,
                    Name = "Community health outreach coverage",
                    Description = "Number of communities receiving regular health outreach services",
                    Unit = "communities",
                    MeasureType = "Quantitative",
                    DataSource = "Outreach program reports",
                    CollectionMethod = "Field team reporting",
                    Frequency = "Monthly",
                    Target = 50,
                    CurrentValue = 38,
                    BaselineValue = 12,
                    LastUpdated = DateTime.Now.AddDays(-4),
                    CreatedAt = new DateTime(2024, 4, 15),
                    IndicatorId = 8,
                    IndicatorName = "Communities served",
                    ProjectId = 4,
                    ProjectName = "Community Health Centers Rehabilitation",
                    Status = "Active",
                    FinancialPerformance = 79.3m,
                    PhysicalPerformance = 76.0m,
                    Trend = 3.7m,
                    Achievement = 76.0m,
                    DataQuality = "Medium",
                    IsVerified = false,
                    ResponsiblePerson = "Dr. Khalil Moussa"
                }
            };
        }
    }
}