using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MEPlatform.Web.Models;
using Newtonsoft.Json;

namespace MEPlatform.Web.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            
            var apiBaseUrl = _configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7001";
            _httpClient.BaseAddress = new Uri(apiBaseUrl);
        }

        public async Task<AuthResult> LoginAsync(LoginViewModel model)
        {
            try
            {
                var loginData = new
                {
                    email = model.Email,
                    password = model.Password
                };

                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/auth/login", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var authResult = JsonConvert.DeserializeObject<AuthResult>(responseContent);
                    if (authResult != null && authResult.Success)
                    {
                        await SetAuthenticationCookieAsync(authResult);
                        return authResult;
                    }
                }

                var errorResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);
                return new AuthResult
                {
                    Success = false,
                    Errors = errorResponse?.Errors ?? new List<string> { "Login failed" }
                };
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { $"Error: {ex.Message}" }
                };
            }
        }

        public async Task<AuthResult> RegisterAsync(RegisterViewModel model)
        {
            try
            {
                var registerData = new
                {
                    email = model.Email,
                    password = model.Password,
                    firstName = model.FirstName,
                    lastName = model.LastName
                };

                var json = JsonConvert.SerializeObject(registerData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/auth/register", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var authResult = JsonConvert.DeserializeObject<AuthResult>(responseContent);
                    if (authResult != null && authResult.Success)
                    {
                        await SetAuthenticationCookieAsync(authResult);
                        return authResult;
                    }
                }

                var errorResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);
                return new AuthResult
                {
                    Success = false,
                    Errors = errorResponse?.Errors ?? new List<string> { "Registration failed" }
                };
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { $"Error: {ex.Message}" }
                };
            }
        }

        public async Task LogoutAsync()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

        public UserInfo? GetCurrentUser()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context?.User?.Identity?.IsAuthenticated == true)
            {
                var claims = context.User.Claims.ToList();
                
                return new UserInfo
                {
                    Id = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0"),
                    Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "",
                    FirstName = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? "",
                    LastName = claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value ?? "",
                    Roles = claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList()
                };
            }
            return null;
        }

        public bool IsInRole(string role)
        {
            var context = _httpContextAccessor.HttpContext;
            return context?.User?.IsInRole(role) ?? false;
        }

        private async Task SetAuthenticationCookieAsync(AuthResult authResult)
        {
            if (authResult.User == null) return;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, authResult.User.Id.ToString()),
                new Claim(ClaimTypes.Email, authResult.User.Email),
                new Claim(ClaimTypes.GivenName, authResult.User.FirstName),
                new Claim(ClaimTypes.Surname, authResult.User.LastName),
                new Claim("Token", authResult.Token),
            };

            foreach (var role in authResult.User.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = authResult.Expiration
            };

            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
            }
        }

        public string? GetToken()
        {
            var context = _httpContextAccessor.HttpContext;
            return context?.User?.FindFirst("Token")?.Value;
        }
    }
}