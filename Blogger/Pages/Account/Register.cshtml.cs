using Core;
using Core.BusinessObject;
using Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Blogger.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IBaseUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RegisterModel(IBaseUserService userService)
        {
            _userService = userService;
        }
        OperationContext Context { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public void OnGet()
        
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            BaseUser user = new BaseUser();
            user.FirstName = Name;
            user.Email = Email;
            user.Password = Password;
            user.CreatedBy =user.UpdatedBy = "System";
            user.CreatedOnUtc =user.UpdatedOnUtc = DateTime.UtcNow;

             OperationResult result = _userService.Add(user, Context);
            if(result.Status == OperationStatus.Success)
            {
                // Creating the security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.FirstName),
                    new Claim(ClaimTypes.Email,user.Email),
                    

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
