using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Services;

namespace MEPlatform.Web.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly AuthService _authService;

        public LogoutModel(AuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _authService.LogoutAsync();
            TempData["InfoMessage"] = "You have been logged out successfully.";
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _authService.LogoutAsync();
            TempData["InfoMessage"] = "You have been logged out successfully.";
            return RedirectToPage("/Index");
        }
    }
}