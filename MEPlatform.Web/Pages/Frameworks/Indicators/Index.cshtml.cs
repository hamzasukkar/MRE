using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Frameworks.Indicators
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [FromQuery]
        public int ElementId { get; set; }

        public ElementSummary? Element { get; set; }
        public FrameworkSummary? Framework { get; set; }
        public List<IndicatorSummary> Indicators { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? elementId)
        {
            if (elementId.HasValue)
            {
                ElementId = elementId.Value;
            }

            try
            {
                // Load element information
                Element = GetMockElement(ElementId);
                if (Element == null)
                {
                    return NotFound();
                }

                // Load framework information
                Framework = GetMockFramework(Element.FrameworkId);

                // Load indicators for this element
                Indicators = GetMockIndicators(ElementId);

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
                
                var indicator = Indicators.FirstOrDefault(i => i.Id == id);
                TempData["SuccessMessage"] = $"Indicator '{indicator?.Name ?? ""}' has been deleted successfully!";
                
                return RedirectToPage(new { elementId = ElementId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting indicator: {ex.Message}";
                return RedirectToPage(new { elementId = ElementId });
            }
        }

        private ElementSummary? GetMockElement(int id)
        {
            var elements = GetMockElements();
            var element = elements.FirstOrDefault(e => e.Id == id);
            
            if (element != null)
            {
                // Add performance data
                element.Performance = id % 3 == 0 ? 92.5m : id % 3 == 1 ? 78.3m : 85.7m;
            }
            
            return element;
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

        private List<ElementSummary> GetMockElements()
        {
            return new List<ElementSummary>
            {
                // SNDV Framework elements
                new() { Id = 1, Name = "Economic Recovery and Development", Type = "Outcome", FrameworkId = 1, Weight = 30, Icon = "graph-up-arrow", Description = "Promote sustainable economic growth and recovery" },
                new() { Id = 2, Name = "Infrastructure Development", Type = "Output", FrameworkId = 1, ParentId = 1, Weight = 50, Icon = "building", Description = "Rebuild critical infrastructure systems" },
                new() { Id = 3, Name = "Road Network Rehabilitation", Type = "SubOutput", FrameworkId = 1, ParentId = 2, Weight = 40, Icon = "road", Description = "Restore and improve road connectivity" },
                new() { Id = 4, Name = "Energy Sector Recovery", Type = "SubOutput", FrameworkId = 1, ParentId = 2, Weight = 60, Icon = "lightning", Description = "Rebuild power generation and distribution" },
                
                new() { Id = 5, Name = "Social Development and Human Capital", Type = "Outcome", FrameworkId = 1, Weight = 40, Icon = "people", Description = "Strengthen social services and human development" },
                new() { Id = 6, Name = "Education System Strengthening", Type = "Output", FrameworkId = 1, ParentId = 5, Weight = 60, Icon = "book", Description = "Improve educational access and quality" },
                new() { Id = 7, Name = "Primary Education Access", Type = "SubOutput", FrameworkId = 1, ParentId = 6, Weight = 70, Icon = "mortarboard", Description = "Ensure all children have access to primary education" },
                
                new() { Id = 8, Name = "Governance and Institution Building", Type = "Outcome", FrameworkId = 1, Weight = 30, Icon = "building-gear", Description = "Strengthen governance and institutional capacity" },
                
                // Programs Framework elements
                new() { Id = 11, Name = "Program Planning and Design", Type = "Outcome", FrameworkId = 2, Weight = 25, Icon = "diagram-3", Description = "Effective program planning and design processes" },
                new() { Id = 12, Name = "Strategic Planning", Type = "Output", FrameworkId = 2, ParentId = 11, Weight = 100, Icon = "bullseye", Description = "Comprehensive strategic planning frameworks" },
                
                new() { Id = 13, Name = "Implementation Management", Type = "Outcome", FrameworkId = 2, Weight = 35, Icon = "gear", Description = "Effective implementation and management systems" },
                new() { Id = 14, Name = "Project Execution", Type = "Output", FrameworkId = 2, ParentId = 13, Weight = 60, Icon = "play-circle", Description = "Efficient project execution processes" },
                new() { Id = 15, Name = "Quality Assurance", Type = "SubOutput", FrameworkId = 2, ParentId = 14, Weight = 100, Icon = "shield-check", Description = "Comprehensive quality assurance systems" },
                
                new() { Id = 16, Name = "Monitoring and Evaluation", Type = "Outcome", FrameworkId = 2, Weight = 40, Icon = "graph-up", Description = "Robust monitoring and evaluation systems" }
            };
        }

        private List<IndicatorSummary> GetMockIndicators(int elementId)
        {
            var allIndicators = new List<IndicatorSummary>
            {
                // Road Network Rehabilitation (ElementId: 3)
                new() { Id = 1, Name = "Kilometers of roads rehabilitated", ElementId = 3, Unit = "km", Target = 500, CurrentValue = 342, Description = "Total kilometers of main roads successfully rehabilitated", CreatedAt = DateTime.Now.AddMonths(-4), MeasurementsCount = 12 },
                new() { Id = 2, Name = "Road quality index improvement", ElementId = 3, Unit = "points", Target = 8.5m, CurrentValue = 7.2m, Description = "Average road quality rating on 10-point scale", CreatedAt = DateTime.Now.AddMonths(-3), MeasurementsCount = 8 },
                
                // Energy Sector Recovery (ElementId: 4)
                new() { Id = 3, Name = "Power generation capacity restored", ElementId = 4, Unit = "MW", Target = 1200, CurrentValue = 890, Description = "Megawatts of electricity generation capacity restored", CreatedAt = DateTime.Now.AddMonths(-5), MeasurementsCount = 15 },
                new() { Id = 4, Name = "Grid connectivity rate", ElementId = 4, Unit = "%", Target = 95, CurrentValue = 78, Description = "Percentage of target areas connected to power grid", CreatedAt = DateTime.Now.AddMonths(-4), MeasurementsCount = 20 },
                new() { Id = 5, Name = "Average daily power availability", ElementId = 4, Unit = "hours", Target = 20, CurrentValue = 16, Description = "Average hours of power availability per day", CreatedAt = DateTime.Now.AddMonths(-3), MeasurementsCount = 30 },
                
                // Primary Education Access (ElementId: 7)
                new() { Id = 6, Name = "Primary school enrollment rate", ElementId = 7, Unit = "%", Target = 95, CurrentValue = 87, Description = "Percentage of school-age children enrolled in primary education", CreatedAt = DateTime.Now.AddMonths(-6), MeasurementsCount = 18 },
                
                // Quality Assurance (ElementId: 15)
                new() { Id = 7, Name = "Quality assurance compliance rate", ElementId = 15, Unit = "%", Target = 100, CurrentValue = 94, Description = "Percentage of projects meeting quality standards", CreatedAt = DateTime.Now.AddMonths(-2), MeasurementsCount = 25 },
                new() { Id = 8, Name = "Audit findings resolution time", ElementId = 15, Unit = "days", Target = 30, CurrentValue = 18, Description = "Average time to resolve audit findings", CreatedAt = DateTime.Now.AddMonths(-1), MeasurementsCount = 14 },
                
                // Strategic Planning (ElementId: 12)
                new() { Id = 9, Name = "Strategic plans completed", ElementId = 12, Unit = "plans", Target = 8, CurrentValue = 6, Description = "Number of comprehensive strategic plans completed", CreatedAt = DateTime.Now.AddMonths(-3), MeasurementsCount = 8 },
                
                // Project Execution (ElementId: 14)
                new() { Id = 10, Name = "Project delivery on time", ElementId = 14, Unit = "%", Target = 85, CurrentValue = 78, Description = "Percentage of projects delivered on or ahead of schedule", CreatedAt = DateTime.Now.AddMonths(-4), MeasurementsCount = 22 }
            };

            return allIndicators.Where(i => i.ElementId == elementId).ToList();
        }
    }
}