using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAuthApp.Pages
{
    public class AboutUsModel : PageModel  
    {
        public string Username { get; set; } = "User"; 

        public void OnGet() { }
    }
}
