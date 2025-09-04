using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Frameworks.Elements
{
    [Authorize(Roles = "SuperAdministrator,Supervisor")]
    public class CreateModel : PageModel
    {
        public int FrameworkId { get; set; }
        
        [FromQuery]
        public string ElementType { get; set; } = "Outcome";
        
        [FromQuery] 
        public int? ParentId { get; set; }

        [BindProperty]
        public CreateElementViewModel Element { get; set; } = new();

        public FrameworkSummary Framework { get; set; } = new();
        public ElementSummary? Parent { get; set; }
        public List<ElementSummary> AvailableParents { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int frameworkId, string? type, int? parentId)
        {
            FrameworkId = frameworkId;
            ElementType = type ?? "Outcome";
            ParentId = parentId;

            try
            {
                // Load framework info
                Framework = GetMockFramework(frameworkId);
                if (Framework == null)
                {
                    return NotFound();
                }

                // Load parent if specified
                if (ParentId.HasValue)
                {
                    Parent = GetMockElement(ParentId.Value);
                    Element.ParentId = ParentId.Value;
                }

                // Load available parents for hierarchical elements
                if (ElementType == "Output")
                {
                    AvailableParents = GetMockElements(frameworkId).Where(e => e.Type == "Outcome").ToList();
                }
                else if (ElementType == "SubOutput")
                {
                    AvailableParents = GetMockElements(frameworkId).Where(e => e.Type == "Output").ToList();
                }

                // Set defaults
                Element.Weight = 100m;
                Element.Icon = GetDefaultIcon(ElementType);

                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync(int frameworkId, string elementType)
        {
            FrameworkId = frameworkId;
            ElementType = elementType;

            if (!ModelState.IsValid)
            {
                // Reload data for form
                Framework = GetMockFramework(frameworkId);
                if (ElementType == "Output")
                {
                    AvailableParents = GetMockElements(frameworkId).Where(e => e.Type == "Outcome").ToList();
                }
                else if (ElementType == "SubOutput")
                {
                    AvailableParents = GetMockElements(frameworkId).Where(e => e.Type == "Output").ToList();
                }

                return Page();
            }

            try
            {
                // TODO: Replace with actual API call
                await Task.Delay(500); // Simulate API call
                
                TempData["SuccessMessage"] = $"{ElementType} '{Element.Name}' has been created successfully!";
                return RedirectToPage("./Index", new { frameworkId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating {ElementType.ToLower()}: {ex.Message}");
                
                // Reload data for form
                Framework = GetMockFramework(frameworkId);
                if (ElementType == "Output")
                {
                    AvailableParents = GetMockElements(frameworkId).Where(e => e.Type == "Outcome").ToList();
                }
                else if (ElementType == "SubOutput")
                {
                    AvailableParents = GetMockElements(frameworkId).Where(e => e.Type == "Output").ToList();
                }

                return Page();
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
            return elements.FirstOrDefault(e => e.Id == id);
        }

        private List<ElementSummary> GetMockElements(int frameworkId)
        {
            var allElements = new List<ElementSummary>
            {
                // SNDV Framework elements
                new() { Id = 1, Name = "Economic Recovery and Development", Type = "Outcome", FrameworkId = 1 },
                new() { Id = 2, Name = "Infrastructure Development", Type = "Output", FrameworkId = 1, ParentId = 1 },
                new() { Id = 5, Name = "Social Development and Human Capital", Type = "Outcome", FrameworkId = 1 },
                new() { Id = 6, Name = "Education System Strengthening", Type = "Output", FrameworkId = 1, ParentId = 5 },
                
                // Programs Framework elements
                new() { Id = 11, Name = "Program Planning and Design", Type = "Outcome", FrameworkId = 2 },
                new() { Id = 12, Name = "Strategic Planning", Type = "Output", FrameworkId = 2, ParentId = 11 },
                new() { Id = 13, Name = "Implementation Management", Type = "Outcome", FrameworkId = 2 },
                new() { Id = 14, Name = "Project Execution", Type = "Output", FrameworkId = 2, ParentId = 13 }
            };

            return frameworkId == 0 ? allElements : allElements.Where(e => e.FrameworkId == frameworkId).ToList();
        }

        private string GetDefaultIcon(string elementType) => elementType switch
        {
            "Outcome" => "target",
            "Output" => "box-arrow-up",
            "SubOutput" => "arrow-up-right",
            _ => "circle"
        };
    }
}