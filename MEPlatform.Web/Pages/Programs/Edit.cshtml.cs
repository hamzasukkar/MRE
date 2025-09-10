using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Programs
{
    [Authorize]
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditProgramViewModel Program { get; set; } = new();

        public List<string> AvailableSectors { get; set; } = new();
        public List<string> AvailableRegions { get; set; } = new();
        public List<string> AvailableStatuses { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Program = GetMockProgram(id);
                if (Program == null)
                {
                    return NotFound();
                }

                PopulateSelectOptions();
                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
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

                TempData["SuccessMessage"] = $"Program '{Program.Name}' has been updated successfully!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error updating program: {ex.Message}");
                PopulateSelectOptions();
                return Page();
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

                var program = GetMockProgram(id);
                TempData["SuccessMessage"] = $"Program '{program?.Name ?? ""}' has been deleted successfully!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting program: {ex.Message}";
                return RedirectToPage("./Index");
            }
        }

        private EditProgramViewModel? GetMockProgram(int id)
        {
            // Mock data - replace with actual API call
            var programs = new List<EditProgramViewModel>
            {
                new() {
                    Id = 1, Name = "Syria Recovery Initiative",
                    Description = "Comprehensive recovery program focusing on infrastructure rebuilding, economic development, and social services restoration.",
                    Status = "Active", StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2025, 12, 31),
                    Budget = 15500000, Manager = "Ahmad Al-Hassan", Donor = "World Bank",
                    SelectedSectors = new List<string> { "Infrastructure", "Health", "Education", "Economic Development" },
                    SelectedRegions = new List<string> { "Damascus", "Aleppo", "Homs" },
                    ProjectsCount = 8, CompletedProjects = 3, ActiveProjects = 5, OverallProgress = 62.5m,
                    CreatedAt = DateTime.Now.AddMonths(-8), Trend = 2.1m, Performance = 75.4m,
                    FinancialPerformance = 78.2m, PhysicalPerformance = 72.6m, OtherPerformance = 75.4m
                },
                new() {
                    Id = 2, Name = "Community Resilience Program",
                    Description = "Building resilient communities through social cohesion, livelihood support, and local capacity development initiatives.",
                    Status = "Active", StartDate = new DateTime(2023, 6, 1), EndDate = new DateTime(2025, 5, 31),
                    Budget = 8900000, Manager = "Fatima Al-Zahra", Donor = "UNDP",
                    SelectedSectors = new List<string> { "Social Development", "Livelihoods", "Community Building" },
                    SelectedRegions = new List<string> { "Daraa", "Latakia", "Tartus" },
                    ProjectsCount = 12, CompletedProjects = 7, ActiveProjects = 5, OverallProgress = 75.8m,
                    CreatedAt = DateTime.Now.AddMonths(-12), Trend = 1.8m, Performance = 82.3m,
                    FinancialPerformance = 79.5m, PhysicalPerformance = 85.1m, OtherPerformance = 82.3m
                },
                new() {
                    Id = 3, Name = "Agricultural Revival Project",
                    Description = "Supporting agricultural productivity, farmer training, and rural development to enhance food security.",
                    Status = "Active", StartDate = new DateTime(2023, 3, 1), EndDate = new DateTime(2024, 12, 31),
                    Budget = 5200000, Manager = "Omar Kaddour", Donor = "FAO",
                    SelectedSectors = new List<string> { "Agriculture", "Food Security", "Rural Development" },
                    SelectedRegions = new List<string> { "Daraa", "Hama", "Al-Hasakah" },
                    ProjectsCount = 6, CompletedProjects = 4, ActiveProjects = 2, OverallProgress = 88.2m,
                    CreatedAt = DateTime.Now.AddMonths(-15), Trend = 3.2m, Performance = 89.7m,
                    FinancialPerformance = 91.3m, PhysicalPerformance = 88.1m, OtherPerformance = 89.7m
                }
            };

            return programs.FirstOrDefault(p => p.Id == id);
        }

        private void PopulateSelectOptions()
        {
            AvailableSectors = new List<string>
            {
                "Agriculture", "Education", "Health", "Infrastructure", 
                "Economic Development", "Social Development", "Water & Sanitation",
                "Energy", "Transportation", "Housing", "Environment",
                "Gender Equality", "Youth Development", "Food Security",
                "Rural Development", "Urban Planning", "Livelihoods", "Community Building"
            };

            AvailableRegions = new List<string>
            {
                "Damascus", "Aleppo", "Homs", "Hama", "Latakia",
                "Daraa", "Deir ez-Zor", "Al-Hasakah", "Ar-Raqqa",
                "As-Suwayda", "Quneitra", "Tartus", "Idlib", "Rif Dimashq"
            };

            AvailableStatuses = new List<string>
            {
                "Planning", "Active", "On Hold", "Completed", "Cancelled"
            };
        }
    }
}