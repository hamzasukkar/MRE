using MEPlatform.Application.Services;
using MEPlatform.Application.DTOs.Programs;
using MEPlatform.API.Authorization;
using MEPlatform.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MEPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProgramsController : ControllerBase
{
    private readonly IProgramService _programService;
    private readonly ILogger<ProgramsController> _logger;

    public ProgramsController(IProgramService programService, ILogger<ProgramsController> logger)
    {
        _programService = programService;
        _logger = logger;
    }

    /// <summary>
    /// Get all programs
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProgramDto>>> GetPrograms()
    {
        try
        {
            var programs = await _programService.GetAllProgramsAsync();
            return Ok(programs);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving programs");
            return StatusCode(500, "An error occurred while retrieving programs");
        }
    }

    /// <summary>
    /// Get program by ID with full details
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProgramDetailsDto>> GetProgram(int id)
    {
        try
        {
            var program = await _programService.GetProgramByIdAsync(id);
            return Ok(program);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving program {ProgramId}", id);
            return StatusCode(500, "An error occurred while retrieving the program");
        }
    }

    /// <summary>
    /// Create new program
    /// </summary>
    [HttpPost]
    [Authorize(Policy = Policies.CanManageProjects)]
    public async Task<ActionResult<ProgramDto>> CreateProgram(CreateProgramDto dto)
    {
        try
        {
            var program = await _programService.CreateProgramAsync(dto);
            return CreatedAtAction(nameof(GetProgram), new { id = program.Id }, program);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating program");
            return StatusCode(500, "An error occurred while creating the program");
        }
    }

    /// <summary>
    /// Update program
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Policy = Policies.CanManageProjects)]
    public async Task<ActionResult<ProgramDto>> UpdateProgram(int id, UpdateProgramDto dto)
    {
        try
        {
            var program = await _programService.UpdateProgramAsync(id, dto);
            return Ok(program);
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
            _logger.LogError(ex, "Error updating program {ProgramId}", id);
            return StatusCode(500, "An error occurred while updating the program");
        }
    }

    /// <summary>
    /// Delete program
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Policy = Policies.CanManageProjects)]
    public async Task<ActionResult> DeleteProgram(int id)
    {
        try
        {
            var result = await _programService.DeleteProgramAsync(id);
            if (!result)
            {
                return NotFound();
            }
            
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting program {ProgramId}", id);
            return StatusCode(500, "An error occurred while deleting the program");
        }
    }

    /// <summary>
    /// Get action plans for a program
    /// </summary>
    [HttpGet("{id}/action-plans")]
    public async Task<ActionResult<IEnumerable<ActionPlanDto>>> GetActionPlans(int id)
    {
        try
        {
            var actionPlans = await _programService.GetActionPlansAsync(id);
            return Ok(actionPlans);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving action plans for program {ProgramId}", id);
            return StatusCode(500, "An error occurred while retrieving action plans");
        }
    }

    /// <summary>
    /// Create action plan for a program
    /// </summary>
    [HttpPost("{id}/action-plans")]
    [Authorize(Policy = Policies.CanManageProjects)]
    public async Task<ActionResult<ActionPlanDto>> CreateActionPlan(int id, CreateActionPlanDto dto)
    {
        try
        {
            dto.ProgramId = id;
            var actionPlan = await _programService.CreateActionPlanAsync(dto);
            return CreatedAtAction(nameof(GetActionPlans), new { id }, actionPlan);
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
            _logger.LogError(ex, "Error creating action plan for program {ProgramId}", id);
            return StatusCode(500, "An error occurred while creating the action plan");
        }
    }

    /// <summary>
    /// Create logical framework element for a program
    /// </summary>
    [HttpPost("{id}/logical-framework")]
    [Authorize(Policy = Policies.CanManageProjects)]
    public async Task<ActionResult<LogicalFrameworkDto>> CreateLogicalFramework(int id, CreateLogicalFrameworkDto dto)
    {
        try
        {
            dto.ProgramId = id;
            var logicalFramework = await _programService.CreateLogicalFrameworkAsync(dto);
            return Ok(logicalFramework);
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
            _logger.LogError(ex, "Error creating logical framework for program {ProgramId}", id);
            return StatusCode(500, "An error occurred while creating the logical framework");
        }
    }

    /// <summary>
    /// Get dimensions for an action plan
    /// </summary>
    [HttpGet("action-plans/{actionPlanId}/dimensions")]
    public async Task<ActionResult<IEnumerable<DimensionDto>>> GetDimensions(int actionPlanId)
    {
        try
        {
            var dimensions = await _programService.GetDimensionsAsync(actionPlanId);
            return Ok(dimensions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving dimensions for action plan {ActionPlanId}", actionPlanId);
            return StatusCode(500, "An error occurred while retrieving dimensions");
        }
    }

    /// <summary>
    /// Create dimension for an action plan
    /// </summary>
    [HttpPost("action-plans/{actionPlanId}/dimensions")]
    [Authorize(Policy = Policies.CanManageProjects)]
    public async Task<ActionResult<DimensionDto>> CreateDimension(int actionPlanId, CreateDimensionDto dto)
    {
        try
        {
            dto.ActionPlanId = actionPlanId;
            var dimension = await _programService.CreateDimensionAsync(dto);
            return Ok(dimension);
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
            _logger.LogError(ex, "Error creating dimension for action plan {ActionPlanId}", actionPlanId);
            return StatusCode(500, "An error occurred while creating the dimension");
        }
    }
}