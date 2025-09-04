using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Frameworks.Elements
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public int FrameworkId { get; set; }
        public FrameworkSummary Framework { get; set; } = new();
        public List<ElementSummary> Elements { get; set; } = new();
        public List<IndicatorSummary> Indicators { get; set; } = new();
        public FrameworkStatistics Statistics { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int frameworkId)
        {
            FrameworkId = frameworkId;
            
            try
            {
                // TODO: Replace with actual API calls
                Framework = GetMockFramework(frameworkId);
                if (Framework == null)
                {
                    return NotFound();
                }

                Elements = CreateMockElements(frameworkId);
                Indicators = CreateMockIndicators();
                Statistics = CalculateStatistics();

                return Page();
            }
            catch (Exception)
            {
                return NotFound();
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
                
                var element = Elements.FirstOrDefault(e => e.Id == id);
                TempData["SuccessMessage"] = $"{element?.Type ?? "Element"} '{element?.Name ?? ""}' has been deleted successfully!";
                
                return RedirectToPage(new { frameworkId = FrameworkId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting element: {ex.Message}";
                return RedirectToPage(new { frameworkId = FrameworkId });
            }
        }

        private FrameworkSummary? GetMockFramework(int id)
        {
            var frameworks = new List<FrameworkSummary>
            {
                new() { Id = 1, Name = "SNDV Framework", Type = "SNDV" },
                new() { Id = 2, Name = "Programs Framework", Type = "Programs" },
                new() { Id = 3, Name = "SDG Framework", Type = "SDG" }
            };
            
            return frameworks.FirstOrDefault(f => f.Id == id);
        }

        private List<ElementSummary> CreateMockElements(int frameworkId)
        {
            return frameworkId switch
            {
                1 => new List<ElementSummary> // SNDV Framework
                {
                    new() { Id = 1, Name = "Economic Recovery and Development", Type = "Outcome", FrameworkId = 1, Weight = 30, Icon = "graph-up-arrow", 
                           Trend = 2.1m, Performance = 78.5m, FinancialPerformance = 82.1m, PhysicalPerformance = 75.2m, OtherPerformance = 78.1m },
                    new() { Id = 2, Name = "Infrastructure Development", Type = "Output", FrameworkId = 1, ParentId = 1, Weight = 50, Icon = "building",
                           Trend = 1.8m, Performance = 71.3m, FinancialPerformance = 68.9m, PhysicalPerformance = 73.7m, OtherPerformance = 71.2m },
                    new() { Id = 3, Name = "Road Network Rehabilitation", Type = "SubOutput", FrameworkId = 1, ParentId = 2, Weight = 40, Icon = "road",
                           Trend = 3.2m, Performance = 85.4m, FinancialPerformance = 88.1m, PhysicalPerformance = 82.7m, OtherPerformance = 85.4m },
                    new() { Id = 4, Name = "Energy Sector Recovery", Type = "SubOutput", FrameworkId = 1, ParentId = 2, Weight = 60, Icon = "lightning",
                           Trend = -0.7m, Performance = 67.8m, FinancialPerformance = 65.2m, PhysicalPerformance = 70.4m, OtherPerformance = 67.8m },
                    
                    new() { Id = 5, Name = "Social Development and Human Capital", Type = "Outcome", FrameworkId = 1, Weight = 40, Icon = "people",
                           Trend = 2.8m, Performance = 81.2m, FinancialPerformance = 79.4m, PhysicalPerformance = 83.1m, OtherPerformance = 81.2m },
                    new() { Id = 6, Name = "Education System Strengthening", Type = "Output", FrameworkId = 1, ParentId = 5, Weight = 60, Icon = "book",
                           Trend = 4.1m, Performance = 89.7m, FinancialPerformance = 87.3m, PhysicalPerformance = 92.1m, OtherPerformance = 89.7m },
                    new() { Id = 7, Name = "Primary Education Access", Type = "SubOutput", FrameworkId = 1, ParentId = 6, Weight = 70, Icon = "mortarboard",
                           Trend = 5.2m, Performance = 91.5m, FinancialPerformance = 89.8m, PhysicalPerformance = 93.2m, OtherPerformance = 91.5m },
                    
                    new() { Id = 8, Name = "Governance and Institution Building", Type = "Outcome", FrameworkId = 1, Weight = 30, Icon = "building-gear",
                           Trend = -1.1m, Performance = 64.3m, FinancialPerformance = 61.8m, PhysicalPerformance = 66.8m, OtherPerformance = 64.3m }
                },
                2 => new List<ElementSummary> // Programs Framework  
                {
                    new() { Id = 11, Name = "Program Planning and Design", Type = "Outcome", FrameworkId = 2, Weight = 25, Icon = "diagram-3",
                           Trend = 1.5m, Performance = 72.4m, FinancialPerformance = 74.1m, PhysicalPerformance = 70.7m, OtherPerformance = 72.4m },
                    new() { Id = 12, Name = "Strategic Planning", Type = "Output", FrameworkId = 2, ParentId = 11, Weight = 100, Icon = "bullseye",
                           Trend = 2.3m, Performance = 79.8m, FinancialPerformance = 81.2m, PhysicalPerformance = 78.4m, OtherPerformance = 79.8m },
                    
                    new() { Id = 13, Name = "Implementation Management", Type = "Outcome", FrameworkId = 2, Weight = 35, Icon = "gear",
                           Trend = -0.8m, Performance = 58.7m, FinancialPerformance = 56.3m, PhysicalPerformance = 61.1m, OtherPerformance = 58.7m },
                    new() { Id = 14, Name = "Project Execution", Type = "Output", FrameworkId = 2, ParentId = 13, Weight = 60, Icon = "play-circle",
                           Trend = 0.4m, Performance = 65.2m, FinancialPerformance = 66.8m, PhysicalPerformance = 63.6m, OtherPerformance = 65.2m },
                    new() { Id = 15, Name = "Quality Assurance", Type = "SubOutput", FrameworkId = 2, ParentId = 14, Weight = 100, Icon = "shield-check",
                           Trend = 3.1m, Performance = 94.2m, FinancialPerformance = 95.7m, PhysicalPerformance = 92.7m, OtherPerformance = 94.2m },
                    
                    new() { Id = 16, Name = "Monitoring and Evaluation", Type = "Outcome", FrameworkId = 2, Weight = 40, Icon = "graph-up",
                           Trend = 2.7m, Performance = 87.3m, FinancialPerformance = 88.9m, PhysicalPerformance = 85.7m, OtherPerformance = 87.3m }
                },
                _ => new List<ElementSummary>()
            };
        }

        private List<IndicatorSummary> CreateMockIndicators()
        {
            return new List<IndicatorSummary>
            {
                new() { Id = 1, Name = "Kilometers of roads rehabilitated", ElementId = 3, Unit = "km", Target = 500 },
                new() { Id = 2, Name = "Power generation capacity restored", ElementId = 4, Unit = "MW", Target = 1200 },
                new() { Id = 3, Name = "Primary school enrollment rate", ElementId = 7, Unit = "%", Target = 95 },
                new() { Id = 4, Name = "Quality assurance compliance rate", ElementId = 15, Unit = "%", Target = 100 },
            };
        }

        private FrameworkStatistics CalculateStatistics()
        {
            return new FrameworkStatistics
            {
                OutcomesCount = Elements.Count(e => e.Type == "Outcome"),
                OutputsCount = Elements.Count(e => e.Type == "Output"),
                SubOutputsCount = Elements.Count(e => e.Type == "SubOutput"),
                IndicatorsCount = Indicators.Count,
                MeasurementsCount = Indicators.Count * 3, // Mock: average 3 measurements per indicator
                OverallProgress = 78.5m
            };
        }
    }
}