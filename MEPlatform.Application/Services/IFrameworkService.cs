using MEPlatform.Application.DTOs.Frameworks;
using MEPlatform.Core.Enums;

namespace MEPlatform.Application.Services;

public interface IFrameworkService
{
    Task<IEnumerable<FrameworkDto>> GetAllFrameworksAsync();
    Task<FrameworkDetailsDto> GetFrameworkByIdAsync(int id);
    Task<FrameworkDto> UpdateFrameworkAsync(int id, UpdateFrameworkDto dto);
    Task<IEnumerable<FrameworkElementDto>> GetFrameworkElementsAsync(int frameworkId, ElementType? type = null);
    Task<FrameworkElementDto> CreateFrameworkElementAsync(CreateFrameworkElementDto dto);
    Task<FrameworkElementDto> UpdateFrameworkElementAsync(int id, UpdateFrameworkElementDto dto);
    Task<bool> DeleteFrameworkElementAsync(int id);
    Task<IEnumerable<IndicatorDto>> GetIndicatorsAsync(int? frameworkElementId = null);
    Task<IndicatorDto> CreateIndicatorAsync(CreateIndicatorDto dto);
    Task<IndicatorDto> UpdateIndicatorAsync(int id, UpdateIndicatorDto dto);
    Task<bool> DeleteIndicatorAsync(int id);
    Task<IEnumerable<MeasurementDto>> GetMeasurementsAsync(int indicatorId);
    Task<MeasurementDto> CreateMeasurementAsync(CreateMeasurementDto dto);
    Task<MeasurementDto> UpdateMeasurementAsync(int id, UpdateMeasurementDto dto);
    Task<bool> DeleteMeasurementAsync(int id);
    Task RecalculatePerformanceAsync(int frameworkId);
}