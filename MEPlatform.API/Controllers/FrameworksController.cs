using MEPlatform.Application.Services;
using MEPlatform.Application.DTOs.Frameworks;
using MEPlatform.API.Authorization;
using MEPlatform.Core.Enums;
using MEPlatform.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MEPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FrameworksController : ControllerBase
{
    private readonly IFrameworkService _frameworkService;
    private readonly ILogger<FrameworksController> _logger;

    public FrameworksController(IFrameworkService frameworkService, ILogger<FrameworksController> logger)
    {
        _frameworkService = frameworkService;
        _logger = logger;
    }

    /// <summary>
    /// Get all frameworks
    /// </summary>
    [HttpGet]
    [Authorize(Policy = Policies.CanViewReports)]
    public async Task<ActionResult<IEnumerable<FrameworkDto>>> GetFrameworks()
    {
        try
        {
            var frameworks = await _frameworkService.GetAllFrameworksAsync();
            return Ok(frameworks);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving frameworks");
            return StatusCode(500, "An error occurred while retrieving frameworks");
        }
    }

    /// <summary>
    /// Get framework by ID with full details
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<FrameworkDetailsDto>> GetFramework(int id)
    {
        try
        {
            var framework = await _frameworkService.GetFrameworkByIdAsync(id);
            return Ok(framework);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving framework {FrameworkId}", id);
            return StatusCode(500, "An error occurred while retrieving the framework");
        }
    }

    /// <summary>
    /// Update framework details
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Policy = Policies.CanManageFrameworks)]
    public async Task<ActionResult<FrameworkDto>> UpdateFramework(int id, UpdateFrameworkDto dto)
    {
        try
        {
            var framework = await _frameworkService.UpdateFrameworkAsync(id, dto);
            return Ok(framework);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating framework {FrameworkId}", id);
            return StatusCode(500, "An error occurred while updating the framework");
        }
    }

    /// <summary>
    /// Get framework elements (outcomes/goals/outputs/etc)
    /// </summary>
    [HttpGet("{frameworkId}/elements")]
    public async Task<ActionResult<IEnumerable<FrameworkElementDto>>> GetFrameworkElements(
        int frameworkId, 
        [FromQuery] ElementType? type = null)
    {
        try
        {
            var elements = await _frameworkService.GetFrameworkElementsAsync(frameworkId, type);
            return Ok(elements);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving framework elements for framework {FrameworkId}", frameworkId);
            return StatusCode(500, "An error occurred while retrieving framework elements");
        }
    }

    /// <summary>
    /// Create new framework element
    /// </summary>
    [HttpPost("elements")]
    [Authorize(Policy = Policies.CanManageFrameworks)]
    public async Task<ActionResult<FrameworkElementDto>> CreateFrameworkElement(CreateFrameworkElementDto dto)
    {
        try
        {
            var element = await _frameworkService.CreateFrameworkElementAsync(dto);
            return CreatedAtAction(nameof(GetFramework), new { id = element.FrameworkId }, element);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating framework element");
            return StatusCode(500, "An error occurred while creating the framework element");
        }
    }

    /// <summary>
    /// Update framework element
    /// </summary>
    [HttpPut("elements/{id}")]
    [Authorize(Policy = Policies.CanManageFrameworks)]
    public async Task<ActionResult<FrameworkElementDto>> UpdateFrameworkElement(int id, UpdateFrameworkElementDto dto)
    {
        try
        {
            var element = await _frameworkService.UpdateFrameworkElementAsync(id, dto);
            return Ok(element);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating framework element {ElementId}", id);
            return StatusCode(500, "An error occurred while updating the framework element");
        }
    }

    /// <summary>
    /// Delete framework element
    /// </summary>
    [HttpDelete("elements/{id}")]
    [Authorize(Policy = Policies.CanManageFrameworks)]
    public async Task<ActionResult> DeleteFrameworkElement(int id)
    {
        try
        {
            var result = await _frameworkService.DeleteFrameworkElementAsync(id);
            if (!result)
            {
                return NotFound();
            }
            
            return NoContent();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting framework element {ElementId}", id);
            return StatusCode(500, "An error occurred while deleting the framework element");
        }
    }

    /// <summary>
    /// Get indicators
    /// </summary>
    [HttpGet("indicators")]
    public async Task<ActionResult<IEnumerable<IndicatorDto>>> GetIndicators([FromQuery] int? frameworkElementId = null)
    {
        try
        {
            var indicators = await _frameworkService.GetIndicatorsAsync(frameworkElementId);
            return Ok(indicators);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving indicators");
            return StatusCode(500, "An error occurred while retrieving indicators");
        }
    }

    /// <summary>
    /// Create new indicator
    /// </summary>
    [HttpPost("indicators")]
    [Authorize(Policy = Policies.CanManageFrameworks)]
    public async Task<ActionResult<IndicatorDto>> CreateIndicator(CreateIndicatorDto dto)
    {
        try
        {
            var indicator = await _frameworkService.CreateIndicatorAsync(dto);
            return Ok(indicator);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating indicator");
            return StatusCode(500, "An error occurred while creating the indicator");
        }
    }

    /// <summary>
    /// Recalculate framework performance metrics
    /// </summary>
    [HttpPost("{id}/recalculate")]
    [Authorize(Policy = Policies.CanManageFrameworks)]
    public async Task<ActionResult> RecalculatePerformance(int id)
    {
        try
        {
            await _frameworkService.RecalculatePerformanceAsync(id);
            return Ok(new { message = "Performance metrics recalculated successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error recalculating performance for framework {FrameworkId}", id);
            return StatusCode(500, "An error occurred while recalculating performance metrics");
        }
    }
}