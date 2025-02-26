using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MyAuthApp.Data;
using System.Threading.Tasks;

namespace MyAuthApp.Pages
{
    [Authorize] 
    public class UserPageModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        public UserPageModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login"); 
            }

            Username = user.UserName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;

            return Page();
        }
    }
}
