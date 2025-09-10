using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Projects
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateProjectViewModel Project { get; set; } = new();

        public List<string> AvailableRegions { get; set; } = new();
        public List<string> AvailableSectors { get; set; } = new();
        public List<string> AvailableFrameworks { get; set; } = new();
        public List<ProgramSummary> AvailablePrograms { get; set; } = new();

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

                TempData["SuccessMessage"] = $"Project '{Project.Name}' has been created successfully!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating project: {ex.Message}");
                PopulateSelectOptions();
                return Page();
            }
        }

        private void PopulateSelectOptions()
        {
            AvailableRegions = new List<string>
            {
                "Damascus", "Aleppo", "Homs", "Hama", "Latakia",
                "Daraa", "Deir ez-Zor", "Al-Hasakah", "Ar-Raqqa",
                "As-Suwayda", "Quneitra", "Tartus", "Idlib", "Rif Dimashq"
            };

            AvailableSectors = new List<string>
            {
                "Agriculture", "Education", "Health", "Infrastructure", 
                "Economic Development", "Social Development", "Water & Sanitation",
                "Energy", "Transportation", "Housing", "Environment",
                "Gender Equality", "Youth Development", "Food Security",
                "Rural Development", "Urban Planning", "Youth & Social Development",
                "Social Infrastructure", "Medical Training", "Microfinance",
                "Community Building", "Livelihoods"
            };

            AvailableFrameworks = new List<string>
            {
                "SNDV Framework", "Programs Framework", "SDG Framework"
            };

            // Mock programs data
            AvailablePrograms = new List<ProgramSummary>
            {
                new() { Id = 1, Name = "Syria Recovery Initiative", Status = "Active" },
                new() { Id = 2, Name = "Community Resilience Program", Status = "Active" },
                new() { Id = 3, Name = "Agricultural Revival Project", Status = "Active" },
                new() { Id = 4, Name = "Youth Empowerment Initiative", Status = "Planning" },
                new() { Id = 5, Name = "Healthcare System Strengthening", Status = "Active" },
                new() { Id = 6, Name = "Women's Economic Empowerment", Status = "Completed" }
            };
        }
    }
}