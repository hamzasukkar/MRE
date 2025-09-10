using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Services;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Programs
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ProgramApiService _programApiService;

        public IndexModel(ProgramApiService programApiService)
        {
            _programApiService = programApiService;
        }

        public List<ProgramSummary> Programs { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                // For now, we'll use mock data until the API DTOs are fully implemented
                Programs = CreateMockProgramSummaries();
            }
            catch (Exception)
            {
                // If API call fails, use mock data as fallback
                Programs = CreateMockProgramSummaries();
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
                
                var program = Programs.FirstOrDefault(p => p.Id == id);
                TempData["SuccessMessage"] = $"Program '{program?.Name ?? ""}' has been deleted successfully!";
                
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting program: {ex.Message}";
                return RedirectToPage();
            }
        }

        private List<ProgramSummary> CreateMockProgramSummaries()
        {
            return new List<ProgramSummary>
            {
                new ProgramSummary
                {
                    Id = 1,
                    Name = "Syria Recovery Initiative",
                    Description = "Comprehensive recovery program focusing on infrastructure rebuilding, economic development, and social services restoration.",
                    Status = "Active",
                    ProjectsCount = 8,
                    CompletedProjects = 3,
                    ActiveProjects = 5,
                    OverallProgress = 62.5m,
                    Budget = 15500000,
                    StartDate = new DateTime(2024, 1, 1),
                    EndDate = new DateTime(2025, 12, 31),
                    Sectors = new List<string> { "Infrastructure", "Health", "Education", "Economic Development" },
                    Regions = new List<string> { "Damascus", "Aleppo", "Homs" },
                    // Performance metrics
                    Trend = 2.3m, Performance = 78.5m, FinancialPerformance = 82.1m, PhysicalPerformance = 75.8m, OtherPerformance = 77.2m,
                    CreatedAt = new DateTime(2024, 1, 15), Manager = "Ahmad Al-Hassan", Donor = "World Bank", FrameworksCount = 2
                },
                new ProgramSummary
                {
                    Id = 2,
                    Name = "Community Resilience Program",
                    Description = "Building resilient communities through social cohesion, livelihood support, and local capacity development initiatives.",
                    Status = "Active",
                    ProjectsCount = 12,
                    CompletedProjects = 7,
                    ActiveProjects = 5,
                    OverallProgress = 75.8m,
                    Budget = 8900000,
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = new DateTime(2025, 5, 31),
                    Sectors = new List<string> { "Social Development", "Livelihoods", "Community Building" },
                    Regions = new List<string> { "Daraa", "Latakia", "Tartus" },
                    // Performance metrics
                    Trend = -1.2m, Performance = 65.3m, FinancialPerformance = 68.7m, PhysicalPerformance = 62.1m, OtherPerformance = 64.8m,
                    CreatedAt = new DateTime(2023, 6, 1), Manager = "Fatima Al-Zahra", Donor = "UNDP", FrameworksCount = 3
                },
                new ProgramSummary
                {
                    Id = 3,
                    Name = "Agricultural Revival Project",
                    Description = "Supporting agricultural productivity, farmer training, and rural development to enhance food security.",
                    Status = "Active",
                    ProjectsCount = 6,
                    CompletedProjects = 4,
                    ActiveProjects = 2,
                    OverallProgress = 88.2m,
                    Budget = 5200000,
                    StartDate = new DateTime(2023, 3, 1),
                    EndDate = new DateTime(2024, 12, 31),
                    Sectors = new List<string> { "Agriculture", "Food Security", "Rural Development" },
                    Regions = new List<string> { "Daraa", "Hama", "Al-Hasakah" },
                    // Performance metrics
                    Trend = 3.7m, Performance = 82.1m, FinancialPerformance = 85.4m, PhysicalPerformance = 79.3m, OtherPerformance = 81.6m,
                    CreatedAt = new DateTime(2023, 3, 1), Manager = "Omar Kaddour", Donor = "FAO", FrameworksCount = 1
                },
                new ProgramSummary
                {
                    Id = 4,
                    Name = "Youth Empowerment Initiative",
                    Description = "Comprehensive youth development program including skills training, employment support, and civic engagement opportunities.",
                    Status = "Planning",
                    ProjectsCount = 4,
                    CompletedProjects = 0,
                    ActiveProjects = 0,
                    OverallProgress = 15.0m,
                    Budget = 3800000,
                    StartDate = new DateTime(2025, 2, 1),
                    EndDate = new DateTime(2026, 8, 31),
                    Sectors = new List<string> { "Youth Development", "Education", "Employment" },
                    Regions = new List<string> { "Damascus", "Aleppo" },
                    // Performance metrics
                    Trend = 0.8m, Performance = 15.0m, FinancialPerformance = 18.4m, PhysicalPerformance = 11.6m, OtherPerformance = 15.0m,
                    CreatedAt = new DateTime(2024, 10, 1), Manager = "Layla Hassan", Donor = "UNICEF", FrameworksCount = 2
                },
                new ProgramSummary
                {
                    Id = 5,
                    Name = "Healthcare System Strengthening",
                    Description = "Rebuilding and modernizing healthcare infrastructure while training medical professionals and improving service delivery.",
                    Status = "Active",
                    ProjectsCount = 9,
                    CompletedProjects = 2,
                    ActiveProjects = 6,
                    OverallProgress = 45.7m,
                    Budget = 12300000,
                    StartDate = new DateTime(2024, 4, 1),
                    EndDate = new DateTime(2026, 3, 31),
                    Sectors = new List<string> { "Health", "Medical Training", "Infrastructure" },
                    Regions = new List<string> { "Damascus", "Aleppo", "Homs", "Latakia" },
                    // Performance metrics
                    Trend = 1.9m, Performance = 45.7m, FinancialPerformance = 48.2m, PhysicalPerformance = 43.2m, OtherPerformance = 45.7m,
                    CreatedAt = new DateTime(2024, 4, 1), Manager = "Dr. Nizar Khoury", Donor = "WHO", FrameworksCount = 2
                },
                new ProgramSummary
                {
                    Id = 6,
                    Name = "Women's Economic Empowerment",
                    Description = "Supporting women's participation in the economy through skills development, microfinance, and business support.",
                    Status = "Completed",
                    ProjectsCount = 8,
                    CompletedProjects = 8,
                    ActiveProjects = 0,
                    OverallProgress = 100.0m,
                    Budget = 2100000,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2024, 6, 30),
                    Sectors = new List<string> { "Gender Equality", "Economic Development", "Microfinance" },
                    Regions = new List<string> { "Damascus", "Homs", "Daraa" },
                    // Performance metrics
                    Trend = 0.0m, Performance = 100.0m, FinancialPerformance = 98.7m, PhysicalPerformance = 100.0m, OtherPerformance = 100.0m,
                    CreatedAt = new DateTime(2023, 1, 1), Manager = "Dr. Amina Saleh", Donor = "UN Women", FrameworksCount = 1
                }
            };
        }
    }
}