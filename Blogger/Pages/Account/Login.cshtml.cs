using Core.BusinessObject;
using Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace Blogger.Pages.Account
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IBaseUserService _userService;
        public LoginModel(IBaseUserService userService)
        {
            _userService = userService;
        }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            BaseUser user = _userService.GetByEmail(Username);
            if (user == null) return Page();
            if (user.Password == Password)
            {
                // Creating the security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.FirstName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim("Admin", user.IsSuperAdmin.ToString()),

            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
            return RedirectToPage("/Post/Index");
        }

            return Page();
    }
}
}
