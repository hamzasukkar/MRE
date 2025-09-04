using MEPlatform.Application.Services;
using MEPlatform.Application.DTOs.Monitoring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MEPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MonitoringController : ControllerBase
{
    private readonly IMonitoringService _monitoringService;
    private readonly ILogger<MonitoringController> _logger;

    public MonitoringController(IMonitoringService monitoringService, ILogger<MonitoringController> logger)
    {
        _monitoringService = monitoringService;
        _logger = logger;
    }

    /// <summary>
    /// Get framework monitoring data
    /// </summary>
    [HttpGet("frameworks")]
    public async Task<ActionResult<MonitoringFrameworkDto>> GetFrameworkMonitoring([FromQuery] int? frameworkId = null)
    {
        try
        {
            var result = await _monitoringService.GetFrameworkMonitoringAsync(frameworkId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving framework monitoring data");
            return StatusCode(500, "An error occurred while retrieving framework monitoring data");
        }
    }

    /// <summary>
    /// Get partners monitoring data
    /// </summary>
    [HttpGet("partners")]
    public async Task<ActionResult<MonitoringPartnersDto>> GetPartnersMonitoring()
    {
        try
        {
            var result = await _monitoringService.GetPartnersMonitoringAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving partners monitoring data");
            return StatusCode(500, "An error occurred while retrieving partners monitoring data");
        }
    }

    /// <summary>
    /// Get regional monitoring data
    /// </summary>
    [HttpGet("regional")]
    public async Task<ActionResult<MonitoringRegionalDto>> GetRegionalMonitoring()
    {
        try
        {
            var result = await _monitoringService.GetRegionalMonitoringAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving regional monitoring data");
            return StatusCode(500, "An error occurred while retrieving regional monitoring data");
        }
    }

    /// <summary>
    /// Get projects monitoring data
    /// </summary>
    [HttpGet("projects")]
    public async Task<ActionResult<IEnumerable<MonitoringProjectDto>>> GetProjectsMonitoring()
    {
        try
        {
            var result = await _monitoringService.GetProjectsMonitoringAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving projects monitoring data");
            return StatusCode(500, "An error occurred while retrieving projects monitoring data");
        }
    }

    /// <summary>
    /// Get Kanban view for different entity types
    /// </summary>
    [HttpGet("kanban/{viewType}")]
    public async Task<ActionResult<IEnumerable<MonitoringKanbanCardDto>>> GetKanbanView(
        string viewType, 
        [FromQuery] int? filterId = null)
    {
        try
        {
            var result = await _monitoringService.GetKanbanViewAsync(viewType, filterId);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving Kanban view for {ViewType}", viewType);
            return StatusCode(500, "An error occurred while retrieving the Kanban view");
        }
    }

    /// <summary>
    /// Get dashboard data
    /// </summary>
    [HttpGet("dashboard")]
    public async Task<ActionResult<DashboardDto>> GetDashboard()
    {
        try
        {
            var result = await _monitoringService.GetDashboardDataAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving dashboard data");
            return StatusCode(500, "An error occurred while retrieving dashboard data");
        }
    }
}