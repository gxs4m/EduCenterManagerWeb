using EduCenterManagerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduCenterManagerWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Console.WriteLine("User:    " + User.Email + ", Password: " + User.Password);
        }
    }
}
