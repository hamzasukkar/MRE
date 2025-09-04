namespace MEPlatform.Web.Models
{
    public class DashboardViewModel
    {
        public DashboardStats Stats { get; set; } = new();
        public List<FrameworkPerformanceCard> FrameworkPerformance { get; set; } = new();
        public List<RecentActivity> RecentActivities { get; set; } = new();
        public List<UpcomingDeadline> UpcomingDeadlines { get; set; } = new();
    }

    public class DashboardStats
    {
        public int TotalFrameworks { get; set; }
        public int TotalPrograms { get; set; }
        public int TotalProjects { get; set; }
        public int ActiveMeasurements { get; set; }
        public decimal OverallProgress { get; set; }
        public int ProjectsOnTrack { get; set; }
        public int ProjectsAtRisk { get; set; }
        public int ProjectsDelayed { get; set; }
    }

    public class FrameworkPerformanceCard
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Progress { get; set; }
        public int TotalProjects { get; set; }
        public int CompletedProjects { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime LastUpdated { get; set; }
    }

    public class RecentActivity
    {
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class UpcomingDeadline
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int DaysUntilDue => (int)(DueDate - DateTime.Now).TotalDays;
    }

    public class ChartData
    {
        public List<string> Labels { get; set; } = new();
        public List<decimal> Data { get; set; } = new();
        public List<string> Colors { get; set; } = new();
    }

    public class PerformanceMetric
    {
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public decimal Target { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal PercentageOfTarget => Target > 0 ? (Value / Target) * 100 : 0;
    }
}