using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Services;

namespace MEPlatform.Web.Pages.Monitoring
{
    [Authorize]
    public class ProjectsModel : PageModel
    {
        private readonly MonitoringApiService _monitoringApiService;

        public ProjectsModel(MonitoringApiService monitoringApiService)
        {
            _monitoringApiService = monitoringApiService;
        }

        public List<ProjectMonitoringItem> Projects { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? FrameworkId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Region { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Sector { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                // For now, we'll use mock data until the API DTOs are fully implemented
                Projects = CreateMockProjectData();
                ApplyFilters();
            }
            catch (Exception)
            {
                // If API call fails, use mock data as fallback
                Projects = CreateMockProjectData();
                ApplyFilters();
            }
        }

        private void ApplyFilters()
        {
            if (FrameworkId.HasValue)
            {
                var frameworkName = FrameworkId.Value switch
                {
                    1 => "SNDV Framework",
                    2 => "Programs Framework",
                    3 => "SDG Framework",
                    _ => ""
                };
                Projects = Projects.Where(p => p.Framework == frameworkName).ToList();
            }

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
        }

        private List<ProjectMonitoringItem> CreateMockProjectData()
        {
            return new List<ProjectMonitoringItem>
            {
                new ProjectMonitoringItem
                {
                    Id = 1,
                    Name = "Healthcare Infrastructure Development",
                    Description = "Rebuilding and modernizing healthcare facilities",
                    Framework = "SNDV Framework",
                    Status = "Active",
                    Progress = 75.2m,
                    Region = "Damascus",
                    Sector = "Health",
                    StartDate = new DateTime(2024, 1, 15),
                    EndDate = new DateTime(2025, 6, 30)
                },
                new ProjectMonitoringItem
                {
                    Id = 2,
                    Name = "Education System Restoration",
                    Description = "Restoring educational facilities and programs",
                    Framework = "SDG Framework",
                    Status = "Active",
                    Progress = 62.8m,
                    Region = "Aleppo",
                    Sector = "Education",
                    StartDate = new DateTime(2024, 2, 1),
                    EndDate = new DateTime(2025, 12, 31)
                },
                new ProjectMonitoringItem
                {
                    Id = 3,
                    Name = "Water Sanitation Initiative",
                    Description = "Improving water supply and sanitation systems",
                    Framework = "Programs Framework",
                    Status = "On Hold",
                    Progress = 45.0m,
                    Region = "Homs",
                    Sector = "Water & Sanitation",
                    StartDate = new DateTime(2024, 3, 1),
                    EndDate = new DateTime(2025, 8, 15)
                },
                new ProjectMonitoringItem
                {
                    Id = 4,
                    Name = "Agricultural Recovery Program",
                    Description = "Supporting farmers and agricultural productivity",
                    Framework = "SNDV Framework",
                    Status = "Active",
                    Progress = 88.5m,
                    Region = "Daraa",
                    Sector = "Agriculture",
                    StartDate = new DateTime(2023, 9, 1),
                    EndDate = new DateTime(2025, 3, 31)
                },
                new ProjectMonitoringItem
                {
                    Id = 5,
                    Name = "Economic Livelihood Support",
                    Description = "Job creation and economic empowerment initiatives",
                    Framework = "SDG Framework",
                    Status = "Planning",
                    Progress = 15.0m,
                    Region = "Latakia",
                    Sector = "Economic Development",
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2026, 12, 31)
                },
                new ProjectMonitoringItem
                {
                    Id = 6,
                    Name = "Community Center Reconstruction",
                    Description = "Rebuilding community spaces and social infrastructure",
                    Framework = "Programs Framework",
                    Status = "Completed",
                    Progress = 100.0m,
                    Region = "Damascus",
                    Sector = "Social Infrastructure",
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = new DateTime(2024, 11, 30)
                },
                new ProjectMonitoringItem
                {
                    Id = 7,
                    Name = "Youth Empowerment Initiative",
                    Description = "Skills training and youth development programs",
                    Framework = "SDG Framework",
                    Status = "Active",
                    Progress = 52.3m,
                    Region = "Aleppo",
                    Sector = "Youth & Social Development",
                    StartDate = new DateTime(2024, 4, 1),
                    EndDate = new DateTime(2025, 10, 31)
                }
            };
        }
    }

    public class ProjectMonitoringItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Framework { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Progress { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}