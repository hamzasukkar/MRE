using MEPlatform.Web.Models;
using MEPlatform.Application.DTOs.Monitoring;
using MEPlatform.Application.DTOs.Frameworks;

namespace MEPlatform.Web.Services
{
    public class MonitoringApiService : BaseApiService
    {
        public MonitoringApiService(HttpClient httpClient, AuthService authService) 
            : base(httpClient, authService)
        {
        }

        public async Task<ApiResponse<DashboardDto>> GetDashboardDataAsync()
        {
            return await GetAsync<DashboardDto>("/api/monitoring/dashboard");
        }

        public async Task<ApiResponse<List<FrameworkPerformanceDto>>> GetFrameworkPerformanceAsync()
        {
            return await GetAsync<List<FrameworkPerformanceDto>>("/api/monitoring/frameworks");
        }

        public async Task<ApiResponse<List<PartnerPerformanceDto>>> GetPartnerPerformanceAsync()
        {
            return await GetAsync<List<PartnerPerformanceDto>>("/api/monitoring/partners");
        }

        public async Task<ApiResponse<List<SectorPerformanceDto>>> GetSectorPerformanceAsync()
        {
            return await GetAsync<List<SectorPerformanceDto>>("/api/monitoring/sectors");
        }

        public async Task<ApiResponse<List<DonorPerformanceDto>>> GetDonorPerformanceAsync()
        {
            return await GetAsync<List<DonorPerformanceDto>>("/api/monitoring/donors");
        }

        public async Task<ApiResponse<List<RegionalPerformanceDto>>> GetRegionalPerformanceAsync()
        {
            return await GetAsync<List<RegionalPerformanceDto>>("/api/monitoring/regions");
        }

        public async Task<ApiResponse<List<ProjectMonitoringDto>>> GetProjectMonitoringAsync(ProjectMonitoringFilter? filter = null)
        {
            var queryString = "";
            if (filter != null)
            {
                var parameters = new List<string>();
                if (filter.ProgramId.HasValue)
                    parameters.Add($"programId={filter.ProgramId}");
                if (filter.FrameworkId.HasValue)
                    parameters.Add($"frameworkId={filter.FrameworkId}");
                if (!string.IsNullOrEmpty(filter.Region))
                    parameters.Add($"region={filter.Region}");
                if (!string.IsNullOrEmpty(filter.Sector))
                    parameters.Add($"sector={filter.Sector}");
                if (!string.IsNullOrEmpty(filter.Status))
                    parameters.Add($"status={filter.Status}");

                if (parameters.Any())
                    queryString = "?" + string.Join("&", parameters);
            }

            return await GetAsync<List<ProjectMonitoringDto>>($"/api/monitoring/projects{queryString}");
        }

        public async Task<ApiResponse<ProjectKanbanDto>> GetProjectKanbanAsync(string viewType)
        {
            return await GetAsync<ProjectKanbanDto>($"/api/monitoring/kanban/{viewType}");
        }

        public async Task<ApiResponse<List<MeasurementDto>>> GetIndicatorMeasurementsAsync(int indicatorId)
        {
            return await GetAsync<List<MeasurementDto>>($"/api/monitoring/indicators/{indicatorId}/measurements");
        }

        public async Task<ApiResponse<MeasurementDto>> CreateMeasurementAsync(CreateMeasurementDto createMeasurementDto)
        {
            return await PostAsync<MeasurementDto>("/api/monitoring/measurements", createMeasurementDto);
        }

        public async Task<ApiResponse<MeasurementDto>> UpdateMeasurementAsync(int id, UpdateMeasurementDto updateMeasurementDto)
        {
            return await PutAsync<MeasurementDto>($"/api/monitoring/measurements/{id}", updateMeasurementDto);
        }

        public async Task<ApiResponse<bool>> DeleteMeasurementAsync(int id)
        {
            return await DeleteAsync($"/api/monitoring/measurements/{id}");
        }
    }

    public class ProjectMonitoringFilter
    {
        public int? ProgramId { get; set; }
        public int? FrameworkId { get; set; }
        public string? Region { get; set; }
        public string? Sector { get; set; }
        public string? Status { get; set; }
    }
}