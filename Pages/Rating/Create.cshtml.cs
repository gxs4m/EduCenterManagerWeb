using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;

namespace EduCenterManagerWeb.Pages.Rating
{
    public class CreateModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public CreateModel(EduCenterManagerContext context)
        {
            _context = context;
        }

        public  IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public Ratings Ratings { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Rating == null || Ratings == null)
            {
                return Page();
            }

            _context.Rating.Add(Ratings);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
