using MEPlatform.Application.DTOs.Monitoring;

namespace MEPlatform.Application.Services;

public interface IMonitoringService
{
    Task<MonitoringFrameworkDto> GetFrameworkMonitoringAsync(int? frameworkId = null);
    Task<MonitoringPartnersDto> GetPartnersMonitoringAsync();
    Task<MonitoringRegionalDto> GetRegionalMonitoringAsync();
    Task<IEnumerable<MonitoringProjectDto>> GetProjectsMonitoringAsync();
    Task<DashboardDto> GetDashboardDataAsync();
    Task<IEnumerable<MonitoringKanbanCardDto>> GetKanbanViewAsync(string viewType, int? filterId = null);
}