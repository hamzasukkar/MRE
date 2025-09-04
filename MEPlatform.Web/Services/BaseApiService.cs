using System.Net.Http.Headers;
using System.Text;
using MEPlatform.Web.Models;
using Newtonsoft.Json;

namespace MEPlatform.Web.Services
{
    public abstract class BaseApiService
    {
        protected readonly HttpClient _httpClient;
        protected readonly AuthService _authService;

        protected BaseApiService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        protected void SetAuthorizationHeader()
        {
            var token = _authService.GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        protected async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            try
            {
                SetAuthorizationHeader();
                var response = await _httpClient.GetAsync(endpoint);
                return await ProcessResponse<T>(response);
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        protected async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                SetAuthorizationHeader();
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(endpoint, content);
                return await ProcessResponse<T>(response);
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        protected async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
        {
            try
            {
                SetAuthorizationHeader();
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(endpoint, content);
                return await ProcessResponse<T>(response);
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        protected async Task<ApiResponse<bool>> DeleteAsync(string endpoint)
        {
            try
            {
                SetAuthorizationHeader();
                var response = await _httpClient.DeleteAsync(endpoint);
                return await ProcessResponse<bool>(response);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        private async Task<ApiResponse<T>> ProcessResponse<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    if (typeof(T) == typeof(bool))
                    {
                        return new ApiResponse<T>
                        {
                            Success = true,
                            Data = (T)(object)true
                        };
                    }

                    var data = JsonConvert.DeserializeObject<T>(content);
                    return new ApiResponse<T>
                    {
                        Success = true,
                        Data = data
                    };
                }
                catch (JsonException)
                {
                    return new ApiResponse<T>
                    {
                        Success = true,
                        Data = (T)(object)content
                    };
                }
            }
            else
            {
                try
                {
                    var errorResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
                    return errorResponse ?? new ApiResponse<T>
                    {
                        Success = false,
                        Message = $"Request failed with status {response.StatusCode}",
                        Errors = new List<string> { content }
                    };
                }
                catch
                {
                    return new ApiResponse<T>
                    {
                        Success = false,
                        Message = $"Request failed with status {response.StatusCode}",
                        Errors = new List<string> { content }
                    };
                }
            }
        }
    }
}