using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MEPlatform.Web.Services;

namespace MEPlatform.Web.Pages.Frameworks
{
    [Authorize(Roles = "SuperAdministrator,Supervisor")]
    public class CreateModel : PageModel
    {
        private readonly FrameworkApiService _frameworkApiService;

        public CreateModel(FrameworkApiService frameworkApiService)
        {
            _frameworkApiService = frameworkApiService;
        }

        [BindProperty]
        public CreateFrameworkViewModel Framework { get; set; } = new();

        public void OnGet()
        {
            // Initialize with defaults
            Framework.Weight = 100;
            Framework.IsActive = true;
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
                // await _frameworkApiService.CreateFrameworkAsync(Framework);
                
                // For now, simulate success
                await Task.Delay(500); // Simulate API call
                
                TempData["SuccessMessage"] = $"Framework '{Framework.Name}' has been created successfully!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating framework: {ex.Message}");
                return Page();
            }
        }
    }

    public class CreateFrameworkViewModel
    {
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
    }
}