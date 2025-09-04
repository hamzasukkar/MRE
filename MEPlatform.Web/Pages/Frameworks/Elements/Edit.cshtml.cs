using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Frameworks.Elements
{
    [Authorize(Roles = "SuperAdministrator,Supervisor")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditElementViewModel Element { get; set; } = new();

        public FrameworkSummary Framework { get; set; } = new();
        public ElementSummary? Parent { get; set; }
        public List<ElementSummary> AvailableParents { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                // Load element data
                var element = GetMockElement(id);
                if (element == null)
                {
                    return NotFound();
                }

                // Map to edit view model
                Element = new EditElementViewModel
                {
                    Id = element.Id,
                    Name = element.Name,
                    Description = element.Description,
                    Weight = element.Weight,
                    Icon = element.Icon,
                    Type = element.Type,
                    FrameworkId = element.FrameworkId,
                    ParentId = element.ParentId,
                    Performance = element.Performance,
                    ChildrenCount = GetChildrenCount(element.Id),
                    IndicatorsCount = GetIndicatorsCount(element.Id),
                    CreatedAt = DateTime.Now.AddMonths(-6) // Mock created date
                };

                // Load framework info
                Framework = GetMockFramework(element.FrameworkId) ?? new();

                // Load parent if exists
                if (element.ParentId.HasValue)
                {
                    Parent = GetMockElement(element.ParentId.Value);
                }

                // Load available parents for hierarchical elements
                if (element.Type == "Output")
                {
                    AvailableParents = GetMockElements(element.FrameworkId).Where(e => e.Type == "Outcome").ToList();
                }
                else if (element.Type == "SubOutput")
                {
                    AvailableParents = GetMockElements(element.FrameworkId).Where(e => e.Type == "Output").ToList();
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
                
                TempData["SuccessMessage"] = $"{Element.Type} '{Element.Name}' has been updated successfully!";
                return RedirectToPage("./Index", new { frameworkId = Element.FrameworkId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error updating {Element.Type.ToLower()}: {ex.Message}");
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
                
                TempData["SuccessMessage"] = $"{Element.Type} '{Element.Name}' has been deleted successfully!";
                return RedirectToPage("./Index", new { frameworkId = Element.FrameworkId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting {Element.Type.ToLower()}: {ex.Message}";
                return RedirectToPage("./Index", new { frameworkId = Element.FrameworkId });
            }
        }

        private async Task ReloadFormData()
        {
            Framework = GetMockFramework(Element.FrameworkId) ?? new();
            
            if (Element.ParentId.HasValue)
            {
                Parent = GetMockElement(Element.ParentId.Value);
            }

            if (Element.Type == "Output")
            {
                AvailableParents = GetMockElements(Element.FrameworkId).Where(e => e.Type == "Outcome").ToList();
            }
            else if (Element.Type == "SubOutput")
            {
                AvailableParents = GetMockElements(Element.FrameworkId).Where(e => e.Type == "Output").ToList();
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

        private ElementSummary? GetMockElement(int id)
        {
            var elements = GetMockElements(0); // Get all elements
            var element = elements.FirstOrDefault(e => e.Id == id);
            
            if (element != null)
            {
                // Add performance data
                element.Performance = id % 3 == 0 ? 92.5m : id % 3 == 1 ? 78.3m : 85.7m;
            }
            
            return element;
        }

        private List<ElementSummary> GetMockElements(int frameworkId)
        {
            var allElements = new List<ElementSummary>
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

            return frameworkId == 0 ? allElements : allElements.Where(e => e.FrameworkId == frameworkId).ToList();
        }

        private int GetChildrenCount(int elementId)
        {
            var allElements = GetMockElements(0);
            return allElements.Count(e => e.ParentId == elementId);
        }

        private int GetIndicatorsCount(int elementId)
        {
            // Mock indicator counts
            return elementId switch
            {
                3 => 2, // Road Network has 2 indicators
                4 => 3, // Energy Sector has 3 indicators
                7 => 1, // Primary Education has 1 indicator
                15 => 2, // Quality Assurance has 2 indicators
                _ => 0
            };
        }
    }
}