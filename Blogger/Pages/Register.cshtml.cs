using Core;
using Core.BusinessObject;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages
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
        public void OnPost()
        {
            BaseUser user = new BaseUser();
            user.FirstName = Name;
            user.Email = Email;
            user.Password = Password;
            user.CreatedBy =user.UpdatedBy = "vikas";
            user.CreatedOnUtc =user.UpdatedOnUtc = DateTime.UtcNow;
            _userService.Add(user, Context);
        }
    }
}
