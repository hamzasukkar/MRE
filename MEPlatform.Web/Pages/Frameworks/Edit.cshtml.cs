using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MEPlatform.Web.Services;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Frameworks
{
    [Authorize(Roles = "SuperAdministrator,Supervisor")]
    public class EditModel : PageModel
    {
        private readonly FrameworkApiService _frameworkApiService;

        public EditModel(FrameworkApiService frameworkApiService)
        {
            _frameworkApiService = frameworkApiService;
        }

        [BindProperty]
        public EditFrameworkViewModel Framework { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                // TODO: Replace with actual API call when implemented
                // var framework = await _frameworkApiService.GetFrameworkByIdAsync(id.Value);
                
                // For now, use mock data
                var mockFramework = GetMockFramework(id.Value);
                if (mockFramework == null)
                {
                    return NotFound();
                }

                Framework = new EditFrameworkViewModel
                {
                    Id = mockFramework.Id,
                    Name = mockFramework.Name,
                    Description = mockFramework.Description,
                    Type = mockFramework.Type,
                    Weight = (decimal)(mockFramework.OverallProgress ?? 100),
                    Icon = GetIconFromType(mockFramework.Type),
                    IsActive = mockFramework.IsActive,
                    ElementsCount = mockFramework.ElementsCount,
                    IndicatorsCount = mockFramework.IndicatorsCount,
                    ProjectsCount = mockFramework.ProjectsCount,
                    CreatedAt = mockFramework.CreatedAt
                };

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
                return Page();
            }

            try
            {
                // TODO: Replace with actual API call when implemented
                // await _frameworkApiService.UpdateFrameworkAsync(Framework.Id, Framework);
                
                // For now, simulate success
                await Task.Delay(500); // Simulate API call
                
                TempData["SuccessMessage"] = $"Framework '{Framework.Name}' has been updated successfully!";
                return RedirectToPage("./Details", new { id = Framework.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error updating framework: {ex.Message}");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            try
            {
                // TODO: Replace with actual API call when implemented
                // await _frameworkApiService.DeleteFrameworkAsync(Framework.Id);
                
                // For now, simulate success
                await Task.Delay(500); // Simulate API call
                
                TempData["SuccessMessage"] = $"Framework '{Framework.Name}' has been deleted successfully!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error deleting framework: {ex.Message}");
                return Page();
            }
        }

        private FrameworkSummary? GetMockFramework(int id)
        {
            var mockFrameworks = new List<FrameworkSummary>
            {
                new FrameworkSummary
                {
                    Id = 1,
                    Name = "SNDV Framework",
                    Description = "Syria National Development Vision 2030 - comprehensive framework for national reconstruction and development priorities.",
                    Type = "SNDV",
                    IsActive = true,
                    ElementsCount = 24,
                    IndicatorsCount = 156,
                    ProjectsCount = 18,
                    OverallProgress = 78.5m,
                    CreatedAt = new DateTime(2024, 1, 15)
                },
                new FrameworkSummary
                {
                    Id = 2,
                    Name = "Programs Framework",
                    Description = "Comprehensive program management and coordination framework for multi-sectoral development initiatives.",
                    Type = "Programs",
                    IsActive = true,
                    ElementsCount = 18,
                    IndicatorsCount = 89,
                    ProjectsCount = 21,
                    OverallProgress = 65.3m,
                    CreatedAt = new DateTime(2024, 2, 1)
                },
                new FrameworkSummary
                {
                    Id = 3,
                    Name = "SDG Framework",
                    Description = "Sustainable Development Goals alignment and monitoring framework adapted for Syria's context and priorities.",
                    Type = "SDG",
                    IsActive = true,
                    ElementsCount = 17,
                    IndicatorsCount = 231,
                    ProjectsCount = 8,
                    OverallProgress = 82.1m,
                    CreatedAt = new DateTime(2024, 1, 30)
                }
            };

            return mockFrameworks.FirstOrDefault(f => f.Id == id);
        }

        private string GetIconFromType(string type)
        {
            return type switch
            {
                "SNDV" => "diagram-3",
                "Programs" => "kanban",
                "SDG" => "globe",
                _ => "diagram-3"
            };
        }
    }

    public class EditFrameworkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Framework name is required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        [Display(Name = "Framework Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Framework type is required")]
        [Display(Name = "Framework Type")]
        public string Type { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "Weight must be between 0 and 100")]
        [Display(Name = "Weight (%)")]
        public decimal Weight { get; set; } = 100;

        [StringLength(50, ErrorMessage = "Icon name cannot be longer than 50 characters")]
        [Display(Name = "Icon")]
        public string? Icon { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        // Read-only properties for display
        public int ElementsCount { get; set; }
        public int IndicatorsCount { get; set; }
        public int ProjectsCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}