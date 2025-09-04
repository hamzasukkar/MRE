using MEPlatform.Web.Models;
using MEPlatform.Application.DTOs.Frameworks;

namespace MEPlatform.Web.Services
{
    public class FrameworkApiService : BaseApiService
    {
        public FrameworkApiService(HttpClient httpClient, AuthService authService) 
            : base(httpClient, authService)
        {
        }

        public async Task<ApiResponse<List<FrameworkDto>>> GetAllFrameworksAsync()
        {
            return await GetAsync<List<FrameworkDto>>("/api/frameworks");
        }

        public async Task<ApiResponse<FrameworkDto>> GetFrameworkByIdAsync(int id)
        {
            return await GetAsync<FrameworkDto>($"/api/frameworks/{id}");
        }

        public async Task<ApiResponse<List<FrameworkElementDto>>> GetFrameworkElementsAsync(int frameworkId)
        {
            return await GetAsync<List<FrameworkElementDto>>($"/api/frameworks/{frameworkId}/elements");
        }

        public async Task<ApiResponse<List<IndicatorDto>>> GetFrameworkIndicatorsAsync(int frameworkId)
        {
            return await GetAsync<List<IndicatorDto>>($"/api/frameworks/{frameworkId}/indicators");
        }

        public async Task<ApiResponse<FrameworkDto>> CreateFrameworkAsync(CreateFrameworkDto createFrameworkDto)
        {
            return await PostAsync<FrameworkDto>("/api/frameworks", createFrameworkDto);
        }

        public async Task<ApiResponse<FrameworkDto>> UpdateFrameworkAsync(int id, UpdateFrameworkDto updateFrameworkDto)
        {
            return await PutAsync<FrameworkDto>($"/api/frameworks/{id}", updateFrameworkDto);
        }

        public async Task<ApiResponse<bool>> DeleteFrameworkAsync(int id)
        {
            return await DeleteAsync($"/api/frameworks/{id}");
        }

        public async Task<ApiResponse<FrameworkElementDto>> CreateElementAsync(CreateFrameworkElementDto createElementDto)
        {
            return await PostAsync<FrameworkElementDto>("/api/frameworks/elements", createElementDto);
        }

        public async Task<ApiResponse<FrameworkElementDto>> UpdateElementAsync(int id, UpdateFrameworkElementDto updateElementDto)
        {
            return await PutAsync<FrameworkElementDto>($"/api/frameworks/elements/{id}", updateElementDto);
        }

        public async Task<ApiResponse<bool>> DeleteElementAsync(int id)
        {
            return await DeleteAsync($"/api/frameworks/elements/{id}");
        }

        public async Task<ApiResponse<IndicatorDto>> CreateIndicatorAsync(CreateIndicatorDto createIndicatorDto)
        {
            return await PostAsync<IndicatorDto>("/api/frameworks/indicators", createIndicatorDto);
        }

        public async Task<ApiResponse<IndicatorDto>> UpdateIndicatorAsync(int id, UpdateIndicatorDto updateIndicatorDto)
        {
            return await PutAsync<IndicatorDto>($"/api/frameworks/indicators/{id}", updateIndicatorDto);
        }

        public async Task<ApiResponse<bool>> DeleteIndicatorAsync(int id)
        {
            return await DeleteAsync($"/api/frameworks/indicators/{id}");
        }
    }
}