using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Programs
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateProgramViewModel Program { get; set; } = new();

        public List<string> AvailableSectors { get; set; } = new();
        public List<string> AvailableRegions { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            // Check authorization
            if (!User.IsInRole("SuperAdministrator") && !User.IsInRole("Supervisor"))
            {
                return Forbid();
            }

            PopulateSelectOptions();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Check authorization
            if (!User.IsInRole("SuperAdministrator") && !User.IsInRole("Supervisor"))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                PopulateSelectOptions();
                return Page();
            }

            try
            {
                // TODO: Replace with actual API call
                await Task.Delay(500); // Simulate API call

                TempData["SuccessMessage"] = $"Program '{Program.Name}' has been created successfully!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating program: {ex.Message}");
                PopulateSelectOptions();
                return Page();
            }
        }

        private void PopulateSelectOptions()
        {
            AvailableSectors = new List<string>
            {
                "Agriculture", "Education", "Health", "Infrastructure", 
                "Economic Development", "Social Development", "Water & Sanitation",
                "Energy", "Transportation", "Housing", "Environment",
                "Gender Equality", "Youth Development", "Food Security",
                "Rural Development", "Urban Planning"
            };

            AvailableRegions = new List<string>
            {
                "Damascus", "Aleppo", "Homs", "Hama", "Latakia",
                "Daraa", "Deir ez-Zor", "Al-Hasakah", "Ar-Raqqa",
                "As-Suwayda", "Quneitra", "Tartus", "Idlib", "Rif Dimashq"
            };
        }
    }
}