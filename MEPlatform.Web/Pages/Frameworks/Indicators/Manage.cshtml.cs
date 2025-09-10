using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Frameworks.Indicators
{
    [Authorize]
    public class ManageModel : PageModel
    {
        public List<IndicatorSummary> Indicators { get; set; } = new();
        public List<FrameworkSummary> Frameworks { get; set; } = new();
        public Dictionary<int, ElementSummary> Elements { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? FrameworkId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Frameworks = GetMockFrameworks();
                Elements = GetMockElements();
                Indicators = GetAllMockIndicators();

                ApplyFilters();
            }
            catch (Exception)
            {
                Frameworks = GetMockFrameworks();
                Elements = GetMockElements();
                Indicators = GetAllMockIndicators();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            // Check authorization
            if (!User.IsInRole("SuperAdministrator") && !User.IsInRole("Supervisor"))
            {
                return Forbid();
            }

            try
            {
                // TODO: Replace with actual API call
                await Task.Delay(500); // Simulate API call
                
                var indicator = Indicators.FirstOrDefault(i => i.Id == id);
                TempData["SuccessMessage"] = $"Indicator '{indicator?.Name ?? ""}' has been deleted successfully!";
                
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting indicator: {ex.Message}";
                return RedirectToPage();
            }
        }

        private void ApplyFilters()
        {
            if (FrameworkId.HasValue)
            {
                var frameworkElements = Elements.Values.Where(e => e.FrameworkId == FrameworkId.Value).Select(e => e.Id).ToList();
                Indicators = Indicators.Where(i => frameworkElements.Contains(i.ElementId)).ToList();
            }

            if (!string.IsNullOrEmpty(Search))
            {
                Indicators = Indicators.Where(i => 
                    i.Name.Contains(Search, StringComparison.OrdinalIgnoreCase) ||
                    (i.Description?.Contains(Search, StringComparison.OrdinalIgnoreCase) ?? false)
                ).ToList();
            }
        }

        private List<FrameworkSummary> GetMockFrameworks()
        {
            return new List<FrameworkSummary>
            {
                new() { Id = 1, Name = "SNDV Framework", Type = "SNDV" },
                new() { Id = 2, Name = "Programs Framework", Type = "Programs" },
                new() { Id = 3, Name = "SDG Framework", Type = "SDG" }
            };
        }

        private Dictionary<int, ElementSummary> GetMockElements()
        {
            var elements = new List<ElementSummary>
            {
                new() { Id = 1, Name = "Economic Recovery and Development", Type = "Outcome", FrameworkId = 1 },
                new() { Id = 2, Name = "Infrastructure Development", Type = "Output", FrameworkId = 1, ParentId = 1 },
                new() { Id = 3, Name = "Road Network Rehabilitation", Type = "SubOutput", FrameworkId = 1, ParentId = 2 },
                new() { Id = 4, Name = "Energy Sector Recovery", Type = "SubOutput", FrameworkId = 1, ParentId = 2 },
                new() { Id = 5, Name = "Social Development and Human Capital", Type = "Outcome", FrameworkId = 1 },
                new() { Id = 6, Name = "Education System Strengthening", Type = "Output", FrameworkId = 1, ParentId = 5 },
                new() { Id = 7, Name = "Primary Education Access", Type = "SubOutput", FrameworkId = 1, ParentId = 6 },
                new() { Id = 8, Name = "Governance and Institution Building", Type = "Outcome", FrameworkId = 1 },
                new() { Id = 11, Name = "Program Planning and Design", Type = "Outcome", FrameworkId = 2 },
                new() { Id = 12, Name = "Strategic Planning", Type = "Output", FrameworkId = 2, ParentId = 11 },
                new() { Id = 13, Name = "Implementation Management", Type = "Outcome", FrameworkId = 2 },
                new() { Id = 14, Name = "Project Execution", Type = "Output", FrameworkId = 2, ParentId = 13 },
                new() { Id = 15, Name = "Quality Assurance", Type = "SubOutput", FrameworkId = 2, ParentId = 14 },
                new() { Id = 16, Name = "Monitoring and Evaluation", Type = "Outcome", FrameworkId = 2 }
            };
            
            return elements.ToDictionary(e => e.Id, e => e);
        }

        private List<IndicatorSummary> GetAllMockIndicators()
        {
            return new List<IndicatorSummary>
            {
                // Road Network Rehabilitation indicators
                new() { Id = 1, Name = "Kilometers of roads rehabilitated", ElementId = 3, Unit = "km", Target = 500, CurrentValue = 342, 
                       Description = "Total kilometers of main roads successfully rehabilitated", CreatedAt = DateTime.Now.AddMonths(-4), 
                       MeasurementsCount = 12, Trend = 2.8m, Performance = 68.4m, FinancialPerformance = 72.1m, PhysicalPerformance = 64.7m, 
                       OtherPerformance = 68.4m, GAGRA = 15.2m, GAGRR = 8.7m, Source = "Engineering Reports", IndicatorImpact = "+", TargetYear = 2024 },
                
                new() { Id = 2, Name = "Road quality index improvement", ElementId = 3, Unit = "points", Target = 8.5m, CurrentValue = 7.2m, 
                       Description = "Average road quality rating on 10-point scale", CreatedAt = DateTime.Now.AddMonths(-3), 
                       MeasurementsCount = 8, Trend = 1.5m, Performance = 84.7m, FinancialPerformance = 85.2m, PhysicalPerformance = 84.2m },

                // Energy Sector Recovery indicators
                new() { Id = 3, Name = "Power generation capacity restored", ElementId = 4, Unit = "MW", Target = 1200, CurrentValue = 890, 
                       Description = "Megawatts of electricity generation capacity restored", CreatedAt = DateTime.Now.AddMonths(-5), 
                       MeasurementsCount = 15, Trend = -0.7m, Performance = 74.2m, FinancialPerformance = 71.8m, PhysicalPerformance = 76.6m },
                
                new() { Id = 4, Name = "Grid connectivity rate", ElementId = 4, Unit = "%", Target = 95, CurrentValue = 78, 
                       Description = "Percentage of target areas connected to power grid", CreatedAt = DateTime.Now.AddMonths(-4), 
                       MeasurementsCount = 20, Trend = 1.2m, Performance = 82.1m, FinancialPerformance = 80.5m, PhysicalPerformance = 83.7m },

                new() { Id = 5, Name = "Average daily power availability", ElementId = 4, Unit = "hours", Target = 20, CurrentValue = 16, 
                       Description = "Average hours of power availability per day", CreatedAt = DateTime.Now.AddMonths(-3), 
                       MeasurementsCount = 30, Trend = 2.1m, Performance = 80.0m, FinancialPerformance = 78.4m, PhysicalPerformance = 81.6m },

                // Primary Education Access indicators
                new() { Id = 6, Name = "Primary school enrollment rate", ElementId = 7, Unit = "%", Target = 95, CurrentValue = 87, 
                       Description = "Percentage of school-age children enrolled in primary education", CreatedAt = DateTime.Now.AddMonths(-6), 
                       MeasurementsCount = 18, Trend = 3.4m, Performance = 91.6m, FinancialPerformance = 89.8m, PhysicalPerformance = 93.4m },

                new() { Id = 7, Name = "Teacher-student ratio improvement", ElementId = 7, Unit = "ratio", Target = 25, CurrentValue = 28, 
                       Description = "Average number of students per teacher", CreatedAt = DateTime.Now.AddMonths(-4), 
                       MeasurementsCount = 12, Trend = -1.1m, Performance = 89.3m, FinancialPerformance = 91.2m, PhysicalPerformance = 87.4m },

                // Quality Assurance indicators
                new() { Id = 8, Name = "Quality assurance compliance rate", ElementId = 15, Unit = "%", Target = 100, CurrentValue = 94, 
                       Description = "Percentage of projects meeting quality standards", CreatedAt = DateTime.Now.AddMonths(-2), 
                       MeasurementsCount = 25, Trend = 2.8m, Performance = 94.0m, FinancialPerformance = 95.2m, PhysicalPerformance = 92.8m },

                new() { Id = 9, Name = "Audit findings resolution time", ElementId = 15, Unit = "days", Target = 30, CurrentValue = 18, 
                       Description = "Average time to resolve audit findings", CreatedAt = DateTime.Now.AddMonths(-1), 
                       MeasurementsCount = 14, Trend = -3.1m, Performance = 100.0m, FinancialPerformance = 98.7m, PhysicalPerformance = 100.0m },

                // Strategic Planning indicators
                new() { Id = 10, Name = "Strategic plans completed", ElementId = 12, Unit = "plans", Target = 8, CurrentValue = 6, 
                       Description = "Number of comprehensive strategic plans completed", CreatedAt = DateTime.Now.AddMonths(-3), 
                       MeasurementsCount = 8, Trend = 1.5m, Performance = 75.0m, FinancialPerformance = 77.8m, PhysicalPerformance = 72.2m },

                // Project Execution indicators
                new() { Id = 11, Name = "Project delivery on time", ElementId = 14, Unit = "%", Target = 85, CurrentValue = 78, 
                       Description = "Percentage of projects delivered on or ahead of schedule", CreatedAt = DateTime.Now.AddMonths(-4), 
                       MeasurementsCount = 22, Trend = 0.8m, Performance = 91.8m, FinancialPerformance = 93.1m, PhysicalPerformance = 90.5m }
            };
        }
    }
}