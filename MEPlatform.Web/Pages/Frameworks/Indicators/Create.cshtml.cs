using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Frameworks.Indicators
{
    [Authorize(Roles = "SuperAdministrator,Supervisor")]
    public class CreateModel : PageModel
    {
        [FromQuery]
        public int ElementId { get; set; }

        [BindProperty]
        public CreateIndicatorViewModel Indicator { get; set; } = new();

        public ElementSummary? Element { get; set; }
        public FrameworkSummary? Framework { get; set; }

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

                // Set defaults
                Indicator.MeasurementFrequency = "Monthly";

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
                Element = GetMockElement(ElementId);
                if (Element != null)
                {
                    Framework = GetMockFramework(Element.FrameworkId);
                }
                return Page();
            }

            try
            {
                // TODO: Replace with actual API call
                await Task.Delay(500); // Simulate API call
                
                TempData["SuccessMessage"] = $"Indicator '{Indicator.Name}' has been created successfully!";
                return RedirectToPage("./Index", new { elementId = ElementId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating indicator: {ex.Message}");
                
                // Reload data for form
                Element = GetMockElement(ElementId);
                if (Element != null)
                {
                    Framework = GetMockFramework(Element.FrameworkId);
                }
                return Page();
            }
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