using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Frameworks.Indicators
{
    [Authorize(Roles = "SuperAdministrator,Supervisor")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditIndicatorViewModel Indicator { get; set; } = new();

        public ElementSummary? Element { get; set; }
        public FrameworkSummary? Framework { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                // Load indicator data
                var indicator = GetMockIndicator(id);
                if (indicator == null)
                {
                    return NotFound();
                }

                // Map to edit view model
                Indicator = new EditIndicatorViewModel
                {
                    Id = indicator.Id,
                    Name = indicator.Name,
                    Description = indicator.Description,
                    Unit = indicator.Unit,
                    Target = indicator.Target,
                    Baseline = indicator.Baseline,
                    CurrentValue = indicator.CurrentValue,
                    MeasurementFrequency = indicator.MeasurementFrequency,
                    DataSource = indicator.DataSource,
                    ResponsibleParty = indicator.ResponsibleParty,
                    ElementId = indicator.ElementId,
                    CreatedAt = indicator.CreatedAt,
                    MeasurementsCount = indicator.MeasurementsCount
                };

                // Load element and framework information
                Element = GetMockElement(indicator.ElementId);
                if (Element != null)
                {
                    Framework = GetMockFramework(Element.FrameworkId);
                }

                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload data for form
                await ReloadFormData();
                return Page();
            }

            try
            {
                // TODO: Replace with actual API call
                await Task.Delay(500); // Simulate API call
                
                TempData["SuccessMessage"] = $"Indicator '{Indicator.Name}' has been updated successfully!";
                return RedirectToPage("./Index", new { elementId = Indicator.ElementId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error updating indicator: {ex.Message}");
                await ReloadFormData();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            try
            {
                // TODO: Replace with actual API call
                await Task.Delay(500); // Simulate API call
                
                TempData["SuccessMessage"] = $"Indicator '{Indicator.Name}' has been deleted successfully!";
                return RedirectToPage("./Index", new { elementId = Indicator.ElementId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting indicator: {ex.Message}";
                return RedirectToPage("./Index", new { elementId = Indicator.ElementId });
            }
        }

        private async Task ReloadFormData()
        {
            Element = GetMockElement(Indicator.ElementId);
            if (Element != null)
            {
                Framework = GetMockFramework(Element.FrameworkId);
            }
        }

        private IndicatorDetail? GetMockIndicator(int id)
        {
            var indicators = new List<IndicatorDetail>
            {
                // Road Network Rehabilitation (ElementId: 3)
                new() { Id = 1, Name = "Kilometers of roads rehabilitated", ElementId = 3, Unit = "km", Target = 500, CurrentValue = 342, Baseline = 0, Description = "Total kilometers of main roads successfully rehabilitated", CreatedAt = DateTime.Now.AddMonths(-4), MeasurementsCount = 12, MeasurementFrequency = "Monthly", DataSource = "Engineering reports", ResponsibleParty = "Infrastructure Team" },
                new() { Id = 2, Name = "Road quality index improvement", ElementId = 3, Unit = "points", Target = 8.5m, CurrentValue = 7.2m, Baseline = 3.2m, Description = "Average road quality rating on 10-point scale", CreatedAt = DateTime.Now.AddMonths(-3), MeasurementsCount = 8, MeasurementFrequency = "Quarterly", DataSource = "Quality assessments", ResponsibleParty = "QA Team" },
                
                // Energy Sector Recovery (ElementId: 4)
                new() { Id = 3, Name = "Power generation capacity restored", ElementId = 4, Unit = "MW", Target = 1200, CurrentValue = 890, Baseline = 200, Description = "Megawatts of electricity generation capacity restored", CreatedAt = DateTime.Now.AddMonths(-5), MeasurementsCount = 15, MeasurementFrequency = "Monthly", DataSource = "Power plant reports", ResponsibleParty = "Energy Team" },
                new() { Id = 4, Name = "Grid connectivity rate", ElementId = 4, Unit = "%", Target = 95, CurrentValue = 78, Baseline = 30, Description = "Percentage of target areas connected to power grid", CreatedAt = DateTime.Now.AddMonths(-4), MeasurementsCount = 20, MeasurementFrequency = "Monthly", DataSource = "Grid monitoring system", ResponsibleParty = "Grid Operations" },
                new() { Id = 5, Name = "Average daily power availability", ElementId = 4, Unit = "hours", Target = 20, CurrentValue = 16, Baseline = 6, Description = "Average hours of power availability per day", CreatedAt = DateTime.Now.AddMonths(-3), MeasurementsCount = 30, MeasurementFrequency = "Weekly", DataSource = "Consumer surveys", ResponsibleParty = "Operations Team" },
                
                // Primary Education Access (ElementId: 7)
                new() { Id = 6, Name = "Primary school enrollment rate", ElementId = 7, Unit = "%", Target = 95, CurrentValue = 87, Baseline = 45, Description = "Percentage of school-age children enrolled in primary education", CreatedAt = DateTime.Now.AddMonths(-6), MeasurementsCount = 18, MeasurementFrequency = "Quarterly", DataSource = "School records", ResponsibleParty = "Education Team" },
                
                // Quality Assurance (ElementId: 15)
                new() { Id = 7, Name = "Quality assurance compliance rate", ElementId = 15, Unit = "%", Target = 100, CurrentValue = 94, Baseline = 70, Description = "Percentage of projects meeting quality standards", CreatedAt = DateTime.Now.AddMonths(-2), MeasurementsCount = 25, MeasurementFrequency = "Monthly", DataSource = "Audit reports", ResponsibleParty = "QA Manager" },
                new() { Id = 8, Name = "Audit findings resolution time", ElementId = 15, Unit = "days", Target = 30, CurrentValue = 18, Baseline = 60, Description = "Average time to resolve audit findings", CreatedAt = DateTime.Now.AddMonths(-1), MeasurementsCount = 14, MeasurementFrequency = "Monthly", DataSource = "Audit tracking system", ResponsibleParty = "Compliance Officer" },
                
                // Strategic Planning (ElementId: 12)
                new() { Id = 9, Name = "Strategic plans completed", ElementId = 12, Unit = "plans", Target = 8, CurrentValue = 6, Baseline = 2, Description = "Number of comprehensive strategic plans completed", CreatedAt = DateTime.Now.AddMonths(-3), MeasurementsCount = 8, MeasurementFrequency = "Quarterly", DataSource = "Planning reports", ResponsibleParty = "Planning Team" },
                
                // Project Execution (ElementId: 14)
                new() { Id = 10, Name = "Project delivery on time", ElementId = 14, Unit = "%", Target = 85, CurrentValue = 78, Baseline = 60, Description = "Percentage of projects delivered on or ahead of schedule", CreatedAt = DateTime.Now.AddMonths(-4), MeasurementsCount = 22, MeasurementFrequency = "Monthly", DataSource = "Project tracking system", ResponsibleParty = "Project Manager" }
            };

            return indicators.FirstOrDefault(i => i.Id == id);
        }

        private ElementSummary? GetMockElement(int id)
        {
            var elements = GetMockElements();
            return elements.FirstOrDefault(e => e.Id == id);
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
    }
}