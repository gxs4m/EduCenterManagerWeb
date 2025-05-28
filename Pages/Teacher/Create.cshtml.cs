using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EduCenterManagerWeb.Models;
using EduCenterManagerWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Teacher
{
    public class CreateModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public CreateModel(EduCenterManagerContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Teachers Teachers { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Teacher == null || Teachers == null)
            {
                return Page();
            }
            _context.Teacher.Add(Teachers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
