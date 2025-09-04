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
                    new() { Id = 1, Name = "Economic Recovery and Development", Type = "Outcome", FrameworkId = 1, Weight = 30, Icon = "graph-up-arrow" },
                    new() { Id = 2, Name = "Infrastructure Development", Type = "Output", FrameworkId = 1, ParentId = 1, Weight = 50, Icon = "building" },
                    new() { Id = 3, Name = "Road Network Rehabilitation", Type = "SubOutput", FrameworkId = 1, ParentId = 2, Weight = 40, Icon = "road" },
                    new() { Id = 4, Name = "Energy Sector Recovery", Type = "SubOutput", FrameworkId = 1, ParentId = 2, Weight = 60, Icon = "lightning" },
                    
                    new() { Id = 5, Name = "Social Development and Human Capital", Type = "Outcome", FrameworkId = 1, Weight = 40, Icon = "people" },
                    new() { Id = 6, Name = "Education System Strengthening", Type = "Output", FrameworkId = 1, ParentId = 5, Weight = 60, Icon = "book" },
                    new() { Id = 7, Name = "Primary Education Access", Type = "SubOutput", FrameworkId = 1, ParentId = 6, Weight = 70, Icon = "mortarboard" },
                    
                    new() { Id = 8, Name = "Governance and Institution Building", Type = "Outcome", FrameworkId = 1, Weight = 30, Icon = "building-gear" }
                },
                2 => new List<ElementSummary> // Programs Framework  
                {
                    new() { Id = 11, Name = "Program Planning and Design", Type = "Outcome", FrameworkId = 2, Weight = 25, Icon = "diagram-3" },
                    new() { Id = 12, Name = "Strategic Planning", Type = "Output", FrameworkId = 2, ParentId = 11, Weight = 100, Icon = "bullseye" },
                    
                    new() { Id = 13, Name = "Implementation Management", Type = "Outcome", FrameworkId = 2, Weight = 35, Icon = "gear" },
                    new() { Id = 14, Name = "Project Execution", Type = "Output", FrameworkId = 2, ParentId = 13, Weight = 60, Icon = "play-circle" },
                    new() { Id = 15, Name = "Quality Assurance", Type = "SubOutput", FrameworkId = 2, ParentId = 14, Weight = 100, Icon = "shield-check" },
                    
                    new() { Id = 16, Name = "Monitoring and Evaluation", Type = "Outcome", FrameworkId = 2, Weight = 40, Icon = "graph-up" }
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