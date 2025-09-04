using MEPlatform.Application.DTOs.Programs;

namespace MEPlatform.Application.Services;

public interface IProgramService
{
    Task<IEnumerable<ProgramDto>> GetAllProgramsAsync();
    Task<ProgramDetailsDto> GetProgramByIdAsync(int id);
    Task<ProgramDto> CreateProgramAsync(CreateProgramDto dto);
    Task<ProgramDto> UpdateProgramAsync(int id, UpdateProgramDto dto);
    Task<bool> DeleteProgramAsync(int id);
    Task<IEnumerable<ActionPlanDto>> GetActionPlansAsync(int programId);
    Task<ActionPlanDto> CreateActionPlanAsync(CreateActionPlanDto dto);
    Task<ActionPlanDto> UpdateActionPlanAsync(int id, UpdateActionPlanDto dto);
    Task<bool> DeleteActionPlanAsync(int id);
    Task<LogicalFrameworkDto> CreateLogicalFrameworkAsync(CreateLogicalFrameworkDto dto);
    Task<LogicalFrameworkDto> UpdateLogicalFrameworkAsync(int id, UpdateLogicalFrameworkDto dto);
    Task<bool> DeleteLogicalFrameworkAsync(int id);
    Task AddProjectAlignmentAsync(int programId, int frameworkElementId);
    Task<bool> RemoveProjectAlignmentAsync(int programId, int frameworkElementId);
    Task<IEnumerable<DimensionDto>> GetDimensionsAsync(int actionPlanId);
    Task<DimensionDto> CreateDimensionAsync(CreateDimensionDto dto);
    Task<DimensionDto> UpdateDimensionAsync(int id, UpdateDimensionDto dto);
    Task<bool> DeleteDimensionAsync(int id);
}