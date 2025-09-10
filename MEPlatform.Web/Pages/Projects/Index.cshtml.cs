using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Projects
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<ProjectSummary> Projects { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Region { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Sector { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? ProgramId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Framework { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Projects = CreateMockProjects();
                ApplyFilters();
            }
            catch (Exception)
            {
                Projects = CreateMockProjects();
                ApplyFilters();
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
                
                var project = Projects.FirstOrDefault(p => p.Id == id);
                TempData["SuccessMessage"] = $"Project '{project?.Name ?? ""}' has been deleted successfully!";
                
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting project: {ex.Message}";
                return RedirectToPage();
            }
        }

        private void ApplyFilters()
        {
            if (!string.IsNullOrEmpty(Status))
            {
                Projects = Projects.Where(p => p.Status == Status).ToList();
            }

            if (!string.IsNullOrEmpty(Region))
            {
                Projects = Projects.Where(p => p.Region == Region).ToList();
            }

            if (!string.IsNullOrEmpty(Sector))
            {
                Projects = Projects.Where(p => p.Sector == Sector).ToList();
            }

            if (ProgramId.HasValue)
            {
                Projects = Projects.Where(p => p.ProgramId == ProgramId.Value).ToList();
            }

            if (!string.IsNullOrEmpty(Framework))
            {
                Projects = Projects.Where(p => p.Framework == Framework).ToList();
            }
        }

        private List<ProjectSummary> CreateMockProjects()
        {
            return new List<ProjectSummary>
            {
                new() {
                    Id = 1, Name = "Healthcare Infrastructure Development", 
                    Description = "Rebuilding and modernizing healthcare facilities across rural areas",
                    Framework = "SNDV Framework", Status = "Active", Progress = 75.2m,
                    Region = "Damascus", Sector = "Health", ProgramId = 1, ProgramName = "Syria Recovery Initiative",
                    StartDate = new DateTime(2024, 1, 15), EndDate = new DateTime(2025, 6, 30),
                    Budget = 2500000, Manager = "Dr. Sarah Al-Khoury", CreatedAt = DateTime.Now.AddMonths(-6),
                    Trend = 2.8m, Performance = 75.2m, FinancialPerformance = 78.1m, PhysicalPerformance = 72.3m, OtherPerformance = 75.2m,
                    IndicatorsCount = 12, MeasurementsCount = 45
                },
                new() {
                    Id = 2, Name = "Education System Restoration",
                    Description = "Restoring educational facilities and programs in conflict-affected areas",
                    Framework = "SDG Framework", Status = "Active", Progress = 62.8m,
                    Region = "Aleppo", Sector = "Education", ProgramId = 1, ProgramName = "Syria Recovery Initiative",
                    StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2025, 12, 31),
                    Budget = 1800000, Manager = "Prof. Ahmad Mansour", CreatedAt = DateTime.Now.AddMonths(-5),
                    Trend = 1.5m, Performance = 62.8m, FinancialPerformance = 65.4m, PhysicalPerformance = 60.2m, OtherPerformance = 62.8m,
                    IndicatorsCount = 8, MeasurementsCount = 28
                },
                new() {
                    Id = 3, Name = "Water Sanitation Initiative",
                    Description = "Improving water supply and sanitation systems in underserved communities",
                    Framework = "Programs Framework", Status = "On Hold", Progress = 45.0m,
                    Region = "Homs", Sector = "Water & Sanitation", ProgramId = 2, ProgramName = "Community Resilience Program",
                    StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2025, 8, 15),
                    Budget = 3200000, Manager = "Eng. Omar Jabri", CreatedAt = DateTime.Now.AddMonths(-4),
                    Trend = -1.2m, Performance = 45.0m, FinancialPerformance = 42.3m, PhysicalPerformance = 47.7m, OtherPerformance = 45.0m,
                    IndicatorsCount = 15, MeasurementsCount = 52
                },
                new() {
                    Id = 4, Name = "Agricultural Recovery Program",
                    Description = "Supporting farmers and agricultural productivity through training and equipment",
                    Framework = "SNDV Framework", Status = "Active", Progress = 88.5m,
                    Region = "Daraa", Sector = "Agriculture", ProgramId = 3, ProgramName = "Agricultural Revival Project",
                    StartDate = new DateTime(2023, 9, 1), EndDate = new DateTime(2025, 3, 31),
                    Budget = 1200000, Manager = "Eng. Fatima Zain", CreatedAt = DateTime.Now.AddMonths(-10),
                    Trend = 3.7m, Performance = 88.5m, FinancialPerformance = 89.2m, PhysicalPerformance = 87.8m, OtherPerformance = 88.5m,
                    IndicatorsCount = 10, MeasurementsCount = 67
                },
                new() {
                    Id = 5, Name = "Economic Livelihood Support",
                    Description = "Job creation and economic empowerment initiatives for vulnerable populations",
                    Framework = "SDG Framework", Status = "Planning", Progress = 15.0m,
                    Region = "Latakia", Sector = "Economic Development", ProgramId = 4, ProgramName = "Youth Empowerment Initiative",
                    StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2026, 12, 31),
                    Budget = 950000, Manager = "Ms. Layla Hassan", CreatedAt = DateTime.Now.AddMonths(-2),
                    Trend = 0.8m, Performance = 15.0m, FinancialPerformance = 18.4m, PhysicalPerformance = 11.6m, OtherPerformance = 15.0m,
                    IndicatorsCount = 6, MeasurementsCount = 8
                },
                new() {
                    Id = 6, Name = "Community Center Reconstruction",
                    Description = "Rebuilding community spaces and social infrastructure",
                    Framework = "Programs Framework", Status = "Completed", Progress = 100.0m,
                    Region = "Damascus", Sector = "Social Infrastructure", ProgramId = 2, ProgramName = "Community Resilience Program",
                    StartDate = new DateTime(2023, 6, 1), EndDate = new DateTime(2024, 11, 30),
                    Budget = 750000, Manager = "Arch. Nour Karam", CreatedAt = DateTime.Now.AddMonths(-8),
                    Trend = 0.0m, Performance = 100.0m, FinancialPerformance = 98.7m, PhysicalPerformance = 100.0m, OtherPerformance = 100.0m,
                    IndicatorsCount = 9, MeasurementsCount = 73
                },
                new() {
                    Id = 7, Name = "Youth Empowerment Initiative",
                    Description = "Skills training and youth development programs",
                    Framework = "SDG Framework", Status = "Active", Progress = 52.3m,
                    Region = "Aleppo", Sector = "Youth & Social Development", ProgramId = 4, ProgramName = "Youth Empowerment Initiative",
                    StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2025, 10, 31),
                    Budget = 680000, Manager = "Mr. Karim Al-Sharif", CreatedAt = DateTime.Now.AddMonths(-3),
                    Trend = 2.1m, Performance = 52.3m, FinancialPerformance = 54.8m, PhysicalPerformance = 49.8m, OtherPerformance = 52.3m,
                    IndicatorsCount = 7, MeasurementsCount = 21
                },
                new() {
                    Id = 8, Name = "Women Economic Empowerment",
                    Description = "Supporting women entrepreneurs and economic participation",
                    Framework = "SDG Framework", Status = "Active", Progress = 67.4m,
                    Region = "Homs", Sector = "Gender Equality", ProgramId = 6, ProgramName = "Women's Economic Empowerment",
                    StartDate = new DateTime(2023, 8, 1), EndDate = new DateTime(2024, 12, 31),
                    Budget = 420000, Manager = "Dr. Amina Saleh", CreatedAt = DateTime.Now.AddMonths(-7),
                    Trend = 4.2m, Performance = 67.4m, FinancialPerformance = 69.1m, PhysicalPerformance = 65.7m, OtherPerformance = 67.4m,
                    IndicatorsCount = 11, MeasurementsCount = 39
                }
            };
        }
    }
}