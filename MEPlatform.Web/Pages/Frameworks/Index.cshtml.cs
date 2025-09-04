using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Services;

namespace MEPlatform.Web.Pages.Frameworks
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FrameworkApiService _frameworkApiService;

        public IndexModel(FrameworkApiService frameworkApiService)
        {
            _frameworkApiService = frameworkApiService;
        }

        public List<FrameworkSummary> Frameworks { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                // For now, we'll use mock data until the API DTOs are fully implemented
                Frameworks = CreateMockFrameworkSummaries();
            }
            catch (Exception)
            {
                // If API call fails, use mock data as fallback
                Frameworks = CreateMockFrameworkSummaries();
            }
        }

        private List<FrameworkSummary> CreateMockFrameworkSummaries()
        {
            return new List<FrameworkSummary>
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
                    CreatedAt = new DateTime(2024, 1, 15),
                    TopLevelElements = new List<string>
                    {
                        "Economic Recovery and Development",
                        "Social Development and Human Capital",
                        "Governance and Institution Building",
                        "Infrastructure and Environment",
                        "Peace and Security"
                    }
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
                    CreatedAt = new DateTime(2024, 2, 1),
                    TopLevelElements = new List<string>
                    {
                        "Program Planning and Design",
                        "Implementation Management",
                        "Monitoring and Evaluation",
                        "Resource Management",
                        "Stakeholder Coordination"
                    }
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
                    CreatedAt = new DateTime(2024, 1, 30),
                    TopLevelElements = new List<string>
                    {
                        "No Poverty (SDG 1)",
                        "Zero Hunger (SDG 2)",
                        "Good Health and Well-being (SDG 3)",
                        "Quality Education (SDG 4)",
                        "Gender Equality (SDG 5)"
                    }
                }
            };
        }
    }

    public class FrameworkSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int ElementsCount { get; set; }
        public int IndicatorsCount { get; set; }
        public int ProjectsCount { get; set; }
        public decimal? OverallProgress { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> TopLevelElements { get; set; } = new();
    }
}