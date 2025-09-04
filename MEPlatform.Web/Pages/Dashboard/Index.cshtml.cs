using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;
using MEPlatform.Web.Services;

namespace MEPlatform.Web.Pages.Dashboard
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly MonitoringApiService _monitoringApiService;

        public IndexModel(MonitoringApiService monitoringApiService)
        {
            _monitoringApiService = monitoringApiService;
        }

        public DashboardViewModel Dashboard { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                // For now, we'll create mock data since the API DTOs might not be available yet
                // In a real implementation, this would call: var result = await _monitoringApiService.GetDashboardDataAsync();
                Dashboard = CreateMockDashboardData();
            }
            catch (Exception)
            {
                // If API call fails, use mock data as fallback
                Dashboard = CreateMockDashboardData();
            }
        }

        private DashboardViewModel CreateMockDashboardData()
        {
            return new DashboardViewModel
            {
                Stats = new DashboardStats
                {
                    TotalFrameworks = 3,
                    TotalPrograms = 12,
                    TotalProjects = 47,
                    ActiveMeasurements = 156,
                    OverallProgress = 73.2m,
                    ProjectsOnTrack = 32,
                    ProjectsAtRisk = 11,
                    ProjectsDelayed = 4
                },
                FrameworkPerformance = new List<FrameworkPerformanceCard>
                {
                    new FrameworkPerformanceCard
                    {
                        Id = 1,
                        Name = "SNDV Framework",
                        Type = "National Development",
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
                        Type = "Program Management",
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
                        Type = "Sustainable Development",
                        Progress = 82.1m,
                        TotalProjects = 8,
                        CompletedProjects = 7,
                        Status = "On Track",
                        LastUpdated = DateTime.Now.AddHours(-1)
                    }
                },
                RecentActivities = new List<RecentActivity>
                {
                    new RecentActivity
                    {
                        Type = "Measurement",
                        Description = "New measurement recorded for Education Sector Progress",
                        User = "Ahmad Hassan",
                        Timestamp = DateTime.Now.AddHours(-1),
                        Icon = "bi-graph-up",
                        Color = "success"
                    },
                    new RecentActivity
                    {
                        Type = "Project",
                        Description = "Healthcare Infrastructure Project marked as completed",
                        User = "Fatima Al-Rashid",
                        Timestamp = DateTime.Now.AddHours(-3),
                        Icon = "bi-check-circle",
                        Color = "primary"
                    },
                    new RecentActivity
                    {
                        Type = "Framework",
                        Description = "SNDV Framework indicators updated",
                        User = "Omar Khalil",
                        Timestamp = DateTime.Now.AddHours(-5),
                        Icon = "bi-diagram-3",
                        Color = "warning"
                    },
                    new RecentActivity
                    {
                        Type = "Program",
                        Description = "New program created: Rural Development Initiative",
                        User = "Layla Mahmoud",
                        Timestamp = DateTime.Now.AddDays(-1),
                        Icon = "bi-folder-plus",
                        Color = "info"
                    }
                },
                UpcomingDeadlines = new List<UpcomingDeadline>
                {
                    new UpcomingDeadline
                    {
                        Title = "Q1 Performance Review",
                        Description = "SNDV Framework quarterly assessment",
                        DueDate = DateTime.Now.AddDays(2),
                        Priority = "High",
                        Type = "Review"
                    },
                    new UpcomingDeadline
                    {
                        Title = "Water Sanitation Project Milestone",
                        Description = "Phase 2 completion deadline",
                        DueDate = DateTime.Now.AddDays(5),
                        Priority = "Medium",
                        Type = "Project"
                    },
                    new UpcomingDeadline
                    {
                        Title = "SDG Progress Report",
                        Description = "Monthly SDG alignment report submission",
                        DueDate = DateTime.Now.AddDays(7),
                        Priority = "Medium",
                        Type = "Report"
                    },
                    new UpcomingDeadline
                    {
                        Title = "Partner Meeting",
                        Description = "Quarterly stakeholder coordination meeting",
                        DueDate = DateTime.Now.AddDays(10),
                        Priority = "Low",
                        Type = "Meeting"
                    }
                }
            };
        }
    }
}