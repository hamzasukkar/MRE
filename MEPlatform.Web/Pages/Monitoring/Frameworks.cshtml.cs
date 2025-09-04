using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;
using MEPlatform.Web.Services;

namespace MEPlatform.Web.Pages.Monitoring
{
    [Authorize]
    public class FrameworksModel : PageModel
    {
        private readonly FrameworkApiService _frameworkApiService;

        public FrameworksModel(FrameworkApiService frameworkApiService)
        {
            _frameworkApiService = frameworkApiService;
        }

        public List<FrameworkPerformanceCard> Frameworks { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                // For now, we'll use mock data until the API DTOs are fully implemented
                Frameworks = CreateMockFrameworkData();
            }
            catch (Exception)
            {
                // If API call fails, use mock data as fallback
                Frameworks = CreateMockFrameworkData();
            }
        }

        private List<FrameworkPerformanceCard> CreateMockFrameworkData()
        {
            return new List<FrameworkPerformanceCard>
            {
                new FrameworkPerformanceCard
                {
                    Id = 1,
                    Name = "SNDV Framework",
                    Type = "Syria National Development Vision",
                    Progress = 78.5m,
                    TotalProjects = 18,
                    CompletedProjects = 14,
                    Status = "On Track",
                    LastUpdated = DateTime.Now.AddHours(-2)
                },
                new FrameworkPerformanceCard
                {
                    Id = 2,
                    Name = "Programs Framework",
                    Type = "Program Management & Coordination",
                    Progress = 65.3m,
                    TotalProjects = 21,
                    CompletedProjects = 14,
                    Status = "At Risk",
                    LastUpdated = DateTime.Now.AddHours(-4)
                },
                new FrameworkPerformanceCard
                {
                    Id = 3,
                    Name = "SDG Framework",
                    Type = "Sustainable Development Goals",
                    Progress = 82.1m,
                    TotalProjects = 8,
                    CompletedProjects = 7,
                    Status = "On Track",
                    LastUpdated = DateTime.Now.AddHours(-1)
                }
            };
        }
    }
}