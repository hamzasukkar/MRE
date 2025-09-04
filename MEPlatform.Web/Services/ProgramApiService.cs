using MEPlatform.Web.Models;
using MEPlatform.Application.DTOs.Programs;

namespace MEPlatform.Web.Services
{
    public class ProgramApiService : BaseApiService
    {
        public ProgramApiService(HttpClient httpClient, AuthService authService) 
            : base(httpClient, authService)
        {
        }

        public async Task<ApiResponse<List<ProgramDto>>> GetAllProgramsAsync()
        {
            return await GetAsync<List<ProgramDto>>("/api/programs");
        }

        public async Task<ApiResponse<ProgramDto>> GetProgramByIdAsync(int id)
        {
            return await GetAsync<ProgramDto>($"/api/programs/{id}");
        }

        public async Task<ApiResponse<List<ProjectDto>>> GetProgramProjectsAsync(int programId)
        {
            return await GetAsync<List<ProjectDto>>($"/api/programs/{programId}/projects");
        }

        public async Task<ApiResponse<ProgramDto>> CreateProgramAsync(CreateProgramDto createProgramDto)
        {
            return await PostAsync<ProgramDto>("/api/programs", createProgramDto);
        }

        public async Task<ApiResponse<ProgramDto>> UpdateProgramAsync(int id, UpdateProgramDto updateProgramDto)
        {
            return await PutAsync<ProgramDto>($"/api/programs/{id}", updateProgramDto);
        }

        public async Task<ApiResponse<bool>> DeleteProgramAsync(int id)
        {
            return await DeleteAsync($"/api/programs/{id}");
        }

        public async Task<ApiResponse<ProjectDto>> CreateProjectAsync(CreateProjectDto createProjectDto)
        {
            return await PostAsync<ProjectDto>("/api/programs/projects", createProjectDto);
        }

        public async Task<ApiResponse<ProjectDto>> UpdateProjectAsync(int id, UpdateProjectDto updateProjectDto)
        {
            return await PutAsync<ProjectDto>($"/api/programs/projects/{id}", updateProjectDto);
        }

        public async Task<ApiResponse<bool>> DeleteProjectAsync(int id)
        {
            return await DeleteAsync($"/api/programs/projects/{id}");
        }
    }
}