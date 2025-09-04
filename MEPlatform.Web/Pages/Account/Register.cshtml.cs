using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;
using MEPlatform.Web.Services;

namespace MEPlatform.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AuthService _authService;

        public RegisterModel(AuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            // Check if user is already logged in
            if (_authService.GetCurrentUser() != null)
            {
                return RedirectToPage("/Dashboard/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = await _authService.RegisterAsync(Input);

                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Registration successful! Welcome to the Syria M&E Platform.";
                    return RedirectToPage("/Dashboard/Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}