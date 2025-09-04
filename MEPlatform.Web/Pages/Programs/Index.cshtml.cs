using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Services;

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
                    Regions = new List<string> { "Damascus", "Aleppo", "Homs" }
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
                    Regions = new List<string> { "Daraa", "Latakia", "Tartus" }
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
                    Regions = new List<string> { "Daraa", "Hama", "Al-Hasakah" }
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
                    Regions = new List<string> { "Damascus", "Aleppo" }
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
                    Regions = new List<string> { "Damascus", "Aleppo", "Homs", "Latakia" }
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
                    Regions = new List<string> { "Damascus", "Homs", "Daraa" }
                }
            };
        }
    }

    public class ProgramSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int ProjectsCount { get; set; }
        public int CompletedProjects { get; set; }
        public int ActiveProjects { get; set; }
        public decimal? OverallProgress { get; set; }
        public decimal? Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Sectors { get; set; } = new();
        public List<string> Regions { get; set; } = new();
    }
}